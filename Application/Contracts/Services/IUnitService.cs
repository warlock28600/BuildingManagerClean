using Application.Dto.Unit;

namespace Application.Contracts.Services;

public interface IUnitService
{
    public Task<UnitGetDto> GetUnitAsync(int id);
    public Task<List<UnitGetDto>> GetUnitByBuildingId(int buildingId);
    public Task<IEnumerable<UnitGetDto>> GetUnitsAsync();
    public Task CreateUnit(UnitCreateDto unitCreateDto);
    public Task UpdateUnit(int id, UnitCreateDto unitCreateDto);
    public Task DeleteUnit(int id);
}