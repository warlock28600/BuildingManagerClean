using Application.Contracts.Repositories;
using AutoMapper;
using BuldingManager.ApplicationDbContext;
using Domain.Entities;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class CompoundRepository : ICompoundRepository
    {
        #region Constructor
        private readonly BuildingDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CompoundRepository> _logger;

        public CompoundRepository(BuildingDbContext context,IMapper mapper, ILogger<CompoundRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region Create Method
        public async Task<bool> CreateCompound(Compounds compound)
        {
            _context.Compounds.Add(compound);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }
        #endregion

        #region Delete Method
        public async Task<bool> DeleteCompound(int id)
        {
            var compound = await GetCompoundById(id);
            if (compound == null)
            {
                _logger.LogError($"Compound with id {id} was not found");
                return false;
            }
            _context.Compounds.Remove(compound);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }
        #endregion

        #region Get Method
        public async Task<Compounds> GetCompoundById(int id)
        {
            var compound = await _context.Compounds.FirstOrDefaultAsync(c=>c.Id==id);
            if (compound == null)
            {
                throw new Exception("Compound not found");
            }
            return compound;
        }

        public async Task<IEnumerable<Compounds>> GetCompounds()
        {
            var compounds = await  _context.Compounds.ToListAsync();
            return compounds;
        }
        #endregion

        #region Update Method
        public async Task<bool> UpdateCompound(int id, Compounds compound)
        {
            var compoundToUpdate =  await GetCompoundById(id);
            if(compoundToUpdate == null)
            {
                throw new Exception("Compound not found");
                _logger.LogError($"Compound with id {id} was not found");
            }
            _mapper.Map(compound, compoundToUpdate);
            var updated = await _context.SaveChangesAsync();
            return updated > 0;
        }
        #endregion
    }
}
