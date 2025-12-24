using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.Dto.UnitExpense;
using AutoMapper;

namespace Application.Services;

public class UnitExpenseService:IUnitExpenseService
{
    private readonly IUnitExpenseRepository _unitExpenseRepository;
    private readonly IMapper _mapper;

    public UnitExpenseService(IUnitExpenseRepository unitExpenseRepository, IMapper mapper)
    {
        _unitExpenseRepository = unitExpenseRepository;
        _mapper = mapper;
    }


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

    public Task<bool> CreateUnitExpanse(UnitExpenseCreateDto unitExpenseCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateUnitExpanse(int id, UnitExpenseCreateDto unitExpenseCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUnitExpanse(int id)
    {
        throw new NotImplementedException();
    }
}