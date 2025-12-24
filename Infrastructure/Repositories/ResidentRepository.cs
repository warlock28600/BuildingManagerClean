using Application.Contracts.Repositories;
using AutoMapper;
using BuldingManager.ApplicationDbContext;
using Domain.Entities;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class ResidentRepository : IResidentRepository
    {
        #region Constructor
        private readonly BuildingDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ResidentRepository> _logger;

        public ResidentRepository(BuildingDbContext context, IMapper mapper, ILogger<ResidentRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion
        
        #region Create Method
        public async Task CreateResident(ResidentEntity resident)
        {
            _context.Residents.Add(resident);
            await _context.SaveChangesAsync();

        }
        #endregion

        #region Delete Method
        public async Task DeleteResident(int id)
        {
            var resident = await GetResidentById(id);
            if (resident != null)
            {
                _context.Residents.Remove(resident);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region Get Method
        public async Task<ResidentEntity?> GetResidentById(int id)
        {
            var resident= await _context.Residents.FirstOrDefaultAsync(r => r.Id == id);
            return resident;
        }

        public async Task<IEnumerable<ResidentEntity>> GetResidents()
        {
            var residents = await _context.Residents.ToListAsync();
            return residents;
        }
        #endregion

        #region Update Method
        public async Task UpdateResident(int id, ResidentEntity resident)
        {
            var residentToUpdate =  await GetResidentById(id);
            if (residentToUpdate != null)
            {
                _mapper.Map(resident, residentToUpdate);
                await _context.SaveChangesAsync();
            }
            else {
                throw new Exception("Resident not found");
                _logger.LogError("the resident with this id was not found");
            }
        }
        #endregion
    }
}
