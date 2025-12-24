using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.Dto.UnitExpense;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class UnitExpenseService:IUnitExpenseService
{
    #region Constructor
    private readonly IUnitExpenseRepository _unitExpenseRepository;
    private readonly IMapper _mapper;

    public UnitExpenseService(IUnitExpenseRepository unitExpenseRepository, IMapper mapper)
    {
        _unitExpenseRepository = unitExpenseRepository;
        _mapper = mapper;
    }
    #endregion
    
    #region Get Methods
    public async Task<IEnumerable<UnitExpenseGetDto>> getAll()
    {
        var unitExpense = await _unitExpenseRepository.GetAll();
        return _mapper.Map<IEnumerable<UnitExpenseGetDto>>(unitExpense);
    }

    public async Task<UnitExpenseGetDto> getById(int id)
    {
        var unitExpense = await _unitExpenseRepository.Get(id);
        return _mapper.Map<UnitExpenseGetDto>(unitExpense);
    }
    #endregion

    #region Create Methods
    public async Task<bool> CreateUnitExpanse(UnitExpenseCreateDto unitExpenseCreateDto)
    {
        var created= await _unitExpenseRepository.Add(_mapper.Map<UnitExpense>(unitExpenseCreateDto));
        return created;
    }
    #endregion

    #region Update Methods
    public Task<bool> UpdateUnitExpanse(int id, UnitExpenseCreateDto unitExpenseCreateDto)
    {
        var updated = _unitExpenseRepository.Update(id, _mapper.Map<UnitExpense>(unitExpenseCreateDto));
        return updated;
    }
    #endregion

    #region Delete Methods
    public Task<bool> DeleteUnitExpanse(int id)
    {
        var deleted = _unitExpenseRepository.Delete(id);
        return deleted;
    }
    #endregion
}