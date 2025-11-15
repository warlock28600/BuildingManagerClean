using Application.Dto.UnitOwner;
using Domain.Entities;

namespace BuldingManager.Repo.UnitOwner;

public interface IUnitOwnerRepository
{
    public Task<IEnumerable<Domain.Entities.UnitOwner>> GetUnitOwners(string extra);
    public Task<Domain.Entities.UnitOwner> GetUnitOwner(int id);
    public Task CreateUnitOwner(Domain.Entities.UnitOwner unitOwner);
    public Task UpdateUnitOwner(int id,Domain.Entities.UnitOwner unitOwner);
    public Task DeleteUnitOwner(int id);
}