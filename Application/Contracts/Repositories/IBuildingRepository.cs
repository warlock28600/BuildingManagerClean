using Application.Dto;
using Domain.Entities;

namespace Application.Contracts.Repositories;

public interface IBuildingRepository
{
    Task<IEnumerable<Domain.Entities.Building>> GetBuildingsAsync();
    Task<Domain.Entities.Building> GetBuildingAsync(int id);
    Task<bool> CreateAsync(Building building);
    Task<bool> UpdateAsync(int id,Building building);
    Task<bool> DeleteAsync(int id);
}