using System.Runtime.InteropServices.JavaScript;
using Application.Dto.Unit;
using Domain.Entities;

namespace BuldingManager.Repo.UnitRepo;

public interface IUnitRepository
{
    public Task<IEnumerable<UnitEntity>> GetAllUnits();
    public Task<List<UnitEntity>> GetUnitByBuildingId(int buildingId);
    public Task<UnitEntity> GetUnitById(int id);
    public Task<bool> CreateUnit( UnitEntity unit);
    public Task<bool> UpdateUnit( int id ,UnitEntity unit);
    public Task<bool> DeleteUnit(int id);
}