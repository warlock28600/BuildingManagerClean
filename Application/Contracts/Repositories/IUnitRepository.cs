using Application.Dto.Unit;
using Domain.Entities;

namespace BuldingManager.Repo.UnitRepo;

public interface IUnitRepository
{
    public Task<IEnumerable<UnitEntity>> GetAllUnits();
    public Task<UnitEntity> GetUnitById(int id);
    public Task CreateUnit( UnitEntity unit);
    public Task UpdateUnit( int id ,UnitCreateDto unit);
    public Task DeleteUnit(int id);
}