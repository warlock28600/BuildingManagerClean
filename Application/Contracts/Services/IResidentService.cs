using Application.Dto.Residents;

namespace Application.Contracts.Services
{
    public interface IResidentService
    {
        public Task<List<ResidentGetDto>> GetResidents();
        public Task<ResidentGetDto> GetResidentById(int id);
        public Task CreateResident(ResidentCreateDto residentDto);
        public Task UpdateResident(int id, ResidentCreateDto residentDto);
        public Task DeleteResident(int id);
    }
}
