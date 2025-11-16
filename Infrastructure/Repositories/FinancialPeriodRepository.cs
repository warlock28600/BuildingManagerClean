
using Application.Contracts.Repositories;
using AutoMapper;
using BuldingManager.ApplicationDbContext;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FinancialPeriodRepository : IFinancialPeriodRepository
    {
        private readonly BuildingDbContext _context;
        private readonly IMapper _mapper;

        public FinancialPeriodRepository(BuildingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateFinancialPeriod(Domain.Entities.FinancialPeriod financialPeriod)
        {
            _context.FinancialPeriods.Add(financialPeriod);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteFinancialPeriod(int id)
        {
            var financialPeriod = await GetFinancialPeriodById(id);
            if (financialPeriod == null)
            {
                throw new Exception("Financial Period not found");
            }
            _context.FinancialPeriods.Remove(financialPeriod);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<Domain.Entities.FinancialPeriod?> GetFinancialPeriodById(int id)
        {
            var financialPeriod = await _context.FinancialPeriods.FirstOrDefaultAsync(f => f.Id == id);
            return financialPeriod;
        }

        public async Task<IEnumerable<Domain.Entities.FinancialPeriod>> GetFinancialPeriods()
        {
            var financialPeriods = await _context.FinancialPeriods.ToListAsync();
            return financialPeriods;
        }

        public async Task<bool> UpdateFinancialPeriod(int id, Domain.Entities.FinancialPeriod financialPeriod)
        {
            var financialPeriodToUpdate = await GetFinancialPeriodById(id);
            if (financialPeriodToUpdate == null)
            {
                throw new Exception("Financial Period not found");
            }
            _mapper.Map(financialPeriod, financialPeriodToUpdate);
            var updated = await _context.SaveChangesAsync();
            return updated > 0;
        }
    }
}
