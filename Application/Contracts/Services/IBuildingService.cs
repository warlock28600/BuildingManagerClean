using Application.Dto;

namespace Application.Contracts.Services;

public interface IBuildingService
{
    public Task<IEnumerable<BuildingGetDto>> GetBuildings();
    public Task<BuildingGetDto> GetBuilding(int id);
    public Task CreateBuilding(BuildingCreateDto buildingCreateDto);
    public Task UpdateBuilding(int id , BuildingCreateDto buildingCreateDto);
    public Task DeleteBuilding(int id);
}  