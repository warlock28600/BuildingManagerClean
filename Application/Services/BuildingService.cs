using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace BuldingManager.Services.Building;

public class BuildingService: IBuildingService
{
    private readonly IBuildingRepository _repository;
    private readonly IMapper _mapper;

    public BuildingService( IBuildingRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async  Task<IEnumerable<BuildingGetDto>> GetBuildings()
    {
        var buildings = await _repository.GetBuildingsAsync();
        return _mapper.Map<IEnumerable<BuildingGetDto>>(buildings);
    }

    public async Task<BuildingGetDto> GetBuilding(int id)
    {
        var building= await _repository.GetBuildingAsync(id);
        return _mapper.Map<BuildingGetDto>(building);
    }

    public async Task CreateBuilding(BuildingCreateDto buildingCreateDto)
    {
       await _repository.CreateAsync(_mapper.Map<Domain.Entities.Building>(buildingCreateDto));
    }

    public async Task UpdateBuilding(int id, BuildingCreateDto buildingCreateDto)
    {
        var buildingEntity= _mapper.Map<Domain.Entities.Building>(buildingCreateDto);
        await _repository.UpdateAsync(id, buildingEntity);
    }

    public async Task DeleteBuilding(int id)
    {
        await _repository.DeleteAsync(id);
    }
}