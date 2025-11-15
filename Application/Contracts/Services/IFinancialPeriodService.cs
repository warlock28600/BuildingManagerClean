using Application.Dto.FinancialPeriod;

namespace Application.Contracts.Services
{
    public interface IFinancialPeriodService
    {
        public Task<IEnumerable<FinancialPeriodGetDto>> GetFinancialPeriods();
        public Task<FinancialPeriodGetDto> GetFinancialPeriodById(int id);
        public Task<bool> CreateFinancialPeriod(FinancialPeriodCreateDto dto);
        public Task<bool> UpdateFinancialPeriod(int id, FinancialPeriodCreateDto dto);
        public Task<bool> DeleteFinancialPeriod(int id);
    }
}
