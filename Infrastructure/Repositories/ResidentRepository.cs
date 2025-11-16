using Application.Contracts.Repositories;
using AutoMapper;
using BuldingManager.ApplicationDbContext;
using Domain.Entities;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ResidentRepository : IResidentRepository
    {
        private readonly BuildingDbContext _context;
        private readonly IMapper _mapper;

        public ResidentRepository(BuildingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task CreateResident(ResidentEntity resident)
        {
            _context.Residents.Add(resident);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteResident(int id)
        {
            var resident = await GetResidentById(id);
            if (resident != null)
            {
                _context.Residents.Remove(resident);
                await _context.SaveChangesAsync();
            }
        }

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
            }
        }
    }
}
