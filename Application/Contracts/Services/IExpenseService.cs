using Application.Dto.Expense;

namespace Application.Contracts.Services
{
    public interface IExpenseService
    {
        public Task<IEnumerable<ExpenseGetDto>> GetExpense();
        public Task<ExpenseGetDto> GetExpenseById(int id);
        public Task<bool> CreateExpense(ExpenceCreateDto expenseCreateDto);
        public Task<bool> UpdateExpense(int id, ExpenceCreateDto expenceCreateDto);
        public Task<bool> DeleteExpense(int id);
    }
}
