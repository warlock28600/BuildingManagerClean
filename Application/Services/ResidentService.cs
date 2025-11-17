using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.Dto.Residents;
using AutoMapper;

namespace Application.Services
{
    public class ResidentService : IResidentService
    {
        private readonly IResidentRepository _residentRepository;
        private readonly IMapper _mapper;

        public ResidentService(IResidentRepository residentRepository,IMapper mapper)
        {
            _residentRepository = residentRepository;
            _mapper = mapper;
        }

        public async Task CreateResident(ResidentCreateDto residentDto)
        {
           await _residentRepository.CreateResident(_mapper.Map<Domain.Entities.ResidentEntity>(residentDto));
        }

        public async Task DeleteResident(int id)
        {
           await _residentRepository.DeleteResident(id);
        }

        public Task<ResidentGetDto> GetResidentById(int id)
        {
            var residentEntity =  _residentRepository.GetResidentById(id);
            return _mapper.Map<Task<ResidentGetDto>>(residentEntity);
        }

        public Task<List<ResidentGetDto>> GetResidents()
        {
           var residentEntities =  _residentRepository.GetResidents();
              return _mapper.Map<Task<List<ResidentGetDto>>>(residentEntities);
        }

        public async Task UpdateResident(int id, ResidentCreateDto residentDto)
        {
            await _residentRepository.UpdateResident(id,_mapper.Map<Domain.Entities.ResidentEntity>(residentDto));
        }
    }
}
