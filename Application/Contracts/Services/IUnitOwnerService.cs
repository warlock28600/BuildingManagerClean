using Application.Dto.UnitOwner;

namespace Application.Contracts.Services;

public interface IUnitOwnerService
{
    public Task<IEnumerable<GetUnitOwnerDto>>  GetUnitOwners(string extra);
    public Task<GetUnitOwnerDto> GetUnitOwner(int id);
    public Task CreateUnitOwner(CreateUnitOwnerDto createUnitOwnerDto);
    public Task UpdateUnitOwner(int id, CreateUnitOwnerDto createUnitOwnerDto);
    public Task DeleteUnitOwner(int id);
    
}