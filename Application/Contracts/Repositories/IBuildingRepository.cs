using Application.Dto;
using Domain.Entities;

namespace Application.Contracts.Repositories;

public interface IBuildingRepository
{
    Task<IEnumerable<Domain.Entities.Building>> GetBuildingsAsync();
    Task<Domain.Entities.Building> GetBuildingAsync(int id);
    Task CreateAsync(BuildingCreateDto building);
    Task UpdateAsync(int id,BuildingCreateDto building);
    Task DeleteAsync(int id);
}