using Application.Contracts.Repositories;
using AutoMapper;
using BuldingManager.ApplicationDbContext;
using Domain.Entities;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CompoundRepository : ICompoundRepository
    {
        private readonly BuildingDbContext _context;
        private readonly IMapper _mapper;

        public CompoundRepository(BuildingDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<bool> CreateCompound(Compounds compound)
        {
            _context.Compounds.Add(compound);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteCompound(int id)
        {
            var compound = await GetCompoundById(id);
            _context.Compounds.Remove(compound);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

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

        public async Task<bool> UpdateCompound(int id, Compounds compound)
        {
            var compoundToUpdate =  await GetCompoundById(id);
            if(compoundToUpdate == null)
            {
                throw new Exception("Compound not found");
            }
            _mapper.Map(compound, compoundToUpdate);
            var updated = await _context.SaveChangesAsync();
            return updated > 0;
        }
    }
}
