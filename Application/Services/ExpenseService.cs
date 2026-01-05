using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.Dto.Expense;
using AutoMapper;

namespace Application.Services
{
    public class ExpenseService : IExpenseService
    {
        #region Constructor
        private readonly IExpenseRepository _expenseRepo;
        private readonly IUnitExpenseService _unitExpenseService;
        private readonly IUnitService _unitService;
        private readonly IMapper _mapper;

        public ExpenseService( IMapper mapper, IExpenseRepository expenseRepo, IUnitExpenseService unitExpenseService, IUnitService unitService)
        {
            _mapper = mapper;
            _expenseRepo = expenseRepo;
            _unitExpenseService = unitExpenseService;
            _unitService = unitService;
        }
        #endregion

        #region Create Method
        public async Task<bool> CreateExpense(ExpenceCreateDto expenseCreateDto)
        {
            var expense = _mapper.Map<Domain.Entities.Expense>(expenseCreateDto);
            return await  _expenseRepo.CreateExpenseAsync(expense);
        }
        #endregion
        
        #region Delete Method
        public async Task<bool> DeleteExpense(int id)
        {
           return await _expenseRepo.DeleteExpenseAsync(id);
        }
        #endregion

        #region Get Method
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
        #endregion 

        #region Update Method
        public Task<bool> UpdateExpense(int id, ExpenceCreateDto expenceCreateDto)
        {
            return _expenseRepo.UpdateExpenseAsync(id, _mapper.Map<Domain.Entities.Expense>(expenceCreateDto));
        }
        #endregion
    }
}
