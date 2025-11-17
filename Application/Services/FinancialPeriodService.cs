using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.Dto.FinancialPeriod;
using AutoMapper;

namespace BuldingManager.Services.FinancialPeriod
{
    public class FinancialPeriodService : IFinancialPeriodService
    {
        private readonly IFinancialPeriodRepository _financialPeriodRepository;
        private readonly IMapper _mapper;

        public FinancialPeriodService(IFinancialPeriodRepository financialPeriodRepository,IMapper mapper)
        {
            _mapper = mapper;
            _financialPeriodRepository = financialPeriodRepository;
        }

        public async Task<bool> CreateFinancialPeriod(FinancialPeriodCreateDto dto)
        {
            var entity = _mapper.Map<Domain.Entities.FinancialPeriod>(dto);
            return await _financialPeriodRepository.CreateFinancialPeriod(entity);
        }

        public async Task<bool> DeleteFinancialPeriod(int id)
        {
            return await _financialPeriodRepository.DeleteFinancialPeriod(id);
        }

        public async Task<FinancialPeriodGetDto> GetFinancialPeriodById(int id)
        {
            var entity = await _financialPeriodRepository.GetFinancialPeriodById(id);
            return _mapper.Map<FinancialPeriodGetDto>(entity);
        }

        public async Task<IEnumerable<FinancialPeriodGetDto>> GetFinancialPeriods()
        {
            var entities = await _financialPeriodRepository.GetFinancialPeriods();
            return _mapper.Map<IEnumerable<FinancialPeriodGetDto>>(entities);
        }

        public async Task<bool> UpdateFinancialPeriod(int id, FinancialPeriodCreateDto dto)
        {
            return await _financialPeriodRepository.UpdateFinancialPeriod(id, _mapper.Map<Domain.Entities.FinancialPeriod>(dto));
        }
    }
}
