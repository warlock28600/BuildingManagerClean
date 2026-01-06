using Application.Contracts.Services;
using Application.Dto.Unit;
using AutoMapper;
using BuldingManager.Repo.UnitRepo;

namespace Application.Services;

public class UnitService:IUnitService
{
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _imapper;
    public UnitService(IMapper imapper, IUnitRepository unitRepository)
    {
        _imapper = imapper;
        _unitRepository = unitRepository;
    }
    
    public async Task<UnitGetDto> GetUnitAsync(int id)
    {
        var unit = await _unitRepository.GetUnitById(id);
        return _imapper.Map<UnitGetDto>(unit);
    }

    public async Task<List<UnitGetDto>> GetUnitByBuildingId(int buildingId)
    {
       var unit = await _unitRepository.GetUnitByBuildingId(buildingId);
       return _imapper.Map<List<UnitGetDto>>(unit);
    }

    public async Task<IEnumerable<UnitGetDto>> GetUnitsAsync()
    {
        var units = await _unitRepository.GetAllUnits();
        return _imapper.Map<IEnumerable<UnitGetDto>>(units);
    }

    public Task CreateUnit(UnitCreateDto unitCreateDto)
    {
        var unitEntity=_imapper.Map<Domain.Entities.UnitEntity>(unitCreateDto);
        return _unitRepository.CreateUnit(unitEntity);
    }

    public async Task UpdateUnit(int id, UnitCreateDto unitCreateDto)
    {
        var unitEntity = _imapper.Map<Domain.Entities.UnitEntity>(unitCreateDto);
        await _unitRepository.UpdateUnit(id, unitEntity);
    }

    public Task DeleteUnit(int id)
    {
       return _unitRepository.DeleteUnit(id);
    }
}