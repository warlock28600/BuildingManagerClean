
using Application.Contracts.Repositories;
using AutoMapper;
using BuldingManager.ApplicationDbContext;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class FinancialPeriodRepository : IFinancialPeriodRepository
    {
        
        #region Constructor
        private readonly BuildingDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<FinancialPeriodRepository> _logger;

        public FinancialPeriodRepository(BuildingDbContext context, IMapper mapper, ILogger<FinancialPeriodRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region Craete Method
        public async Task<bool> CreateFinancialPeriod(Domain.Entities.FinancialPeriod financialPeriod)
        {
            _context.FinancialPeriods.Add(financialPeriod);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }
        #endregion

        #region Delete Method
        public async Task<bool> DeleteFinancialPeriod(int id)
        {
            var financialPeriod = await GetFinancialPeriodById(id);
            if (financialPeriod == null)
            {
                throw new Exception("Financial Period not found");
                _logger.LogError($"Financial Period with id {id} was not found");
            }
            _context.FinancialPeriods.Remove(financialPeriod);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }
        #endregion

        #region Get Method
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
        #endregion

        #region Update Method
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
        #endregion
        
    }
}
