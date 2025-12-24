using Application.Dto.UnitExpense;

namespace Application.Contracts.Services;

public interface IUnitExpenseService
{
    public Task<IEnumerable<UnitExpenseGetDto>> getAll();
    public Task<UnitExpenseGetDto> getById(int id);
    public Task<bool> CreateUnitExpanse(UnitExpenseCreateDto unitExpenseCreateDto);
    public Task<bool> UpdateUnitExpanse(int id,UnitExpenseCreateDto unitExpenseCreateDto);
    public Task<bool> DeleteUnitExpanse(int id);
}