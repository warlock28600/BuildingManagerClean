using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.Dto.Expense;
using AutoMapper;

namespace BuldingManager.Services.Expense
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepo;
        private readonly IMapper _mapper;

        public ExpenseService( IMapper mapper, IExpenseRepository expenseRepo)
        {
            _mapper = mapper;
            _expenseRepo = expenseRepo;
        }

        public async Task<bool> CreateExpense(ExpenceCreateDto expenseCreateDto)
        {
            var expense = _mapper.Map<Domain.Entities.Expense>(expenseCreateDto);
            return await  _expenseRepo.CreateExpenseAsync(expense);
        }

        public async Task<bool> DeleteExpense(int id)
        {
           return await _expenseRepo.DeleteExpenseAsync(id);
        }

        public async Task<IEnumerable<ExpenseGetDto>> GetExpense()
        {
            var expenses =await _expenseRepo.GetExpensesAsync();
            return _mapper.Map<IEnumerable<ExpenseGetDto>>(expenses);
        }

        public async Task<ExpenseGetDto> GetExpenseById(int id)
        {
            var expense = await  _expenseRepo.GetExpenseByIdAsync(id);
            return _mapper.Map<ExpenseGetDto>(expense);
        }

        public Task<bool> UpdateExpense(int id, ExpenceCreateDto expenceCreateDto)
        {
            return _expenseRepo.UpdateExpenseAsync(id, _mapper.Map<Domain.Entities.Expense>(expenceCreateDto));
        }
    }
}
