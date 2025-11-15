namespace Application.Contracts.Repositories
{
    public interface IExpenseRepository
    {
        public Task<IEnumerable<Domain.Entities.Expense>> GetExpensesAsync();
        public Task<Domain.Entities.Expense?> GetExpenseByIdAsync(int id);
        public Task<bool> CreateExpenseAsync(Domain.Entities.Expense expense);
        public Task<bool> UpdateExpenseAsync(int id,Domain.Entities.Expense expense);
        public Task<bool> DeleteExpenseAsync(int id);
    }
}
