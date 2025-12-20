using Domain.Entities;

namespace Application.Contracts.Repositories;

public interface IUnitExpenseRepository
{
    public Task<IEnumerable<UnitExpense>> GetAll();
    public Task<UnitExpense> Get(int id);
    public Task<bool> Add(UnitExpense unitExpense);
    public Task<bool> Update(int id,UnitExpense unitExpense);
    public Task<bool> Delete(int id);
}