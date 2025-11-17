using Application.Contracts.Services;
using Application.Dto.UnitOwner;
using AutoMapper;
using BuldingManager.Repo.UnitOwner;

namespace BuldingManager.Services.UnitOwner;

public class UnitOwnerService:IUnitOwnerService
{
    private readonly IUnitOwnerRepository _unitOwnerRepository;
    private readonly IMapper _mapper;

    public UnitOwnerService(IUnitOwnerRepository unitOwnerRepository, IMapper mapper)
    {
        _unitOwnerRepository = unitOwnerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetUnitOwnerDto>> GetUnitOwners(string extra)
    {
        var unitOwners = await _unitOwnerRepository.GetUnitOwners(extra);
        return _mapper.Map<IEnumerable<GetUnitOwnerDto>>(unitOwners);
    }

    public async Task<GetUnitOwnerDto> GetUnitOwner(int id)
    {
        var unitOwner = await _unitOwnerRepository.GetUnitOwner(id);
        return _mapper.Map<GetUnitOwnerDto>(unitOwner);
    }

    public async Task CreateUnitOwner(CreateUnitOwnerDto createUnitOwnerDto)
    { 
      await  _unitOwnerRepository.CreateUnitOwner(_mapper.Map<Domain.Entities.UnitOwner>(createUnitOwnerDto));
    }

    public async Task UpdateUnitOwner(int id, CreateUnitOwnerDto createUnitOwnerDto)
    {
        await _unitOwnerRepository.UpdateUnitOwner(id, _mapper.Map<Domain.Entities.UnitOwner>(createUnitOwnerDto));
    }

    public async Task DeleteUnitOwner(int id)
    {
        await _unitOwnerRepository.DeleteUnitOwner(id);
    }
}