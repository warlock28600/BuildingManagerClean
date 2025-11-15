namespace Application.Contracts.Repositories
{
    public interface IFinancialPeriodRepository
    {
        public Task<IEnumerable<Domain.Entities.FinancialPeriod>> GetFinancialPeriods();
        public Task<Domain.Entities.FinancialPeriod?> GetFinancialPeriodById(int id);
        public Task<bool> CreateFinancialPeriod(Domain.Entities.FinancialPeriod financialPeriod);
        public Task<bool> UpdateFinancialPeriod(int id,Domain.Entities.FinancialPeriod financialPeriod);
        public Task<bool> DeleteFinancialPeriod(int id);
    }
}
