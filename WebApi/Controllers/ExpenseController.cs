
using Application.Contracts.Services;
using Application.Dto.Expense;
using Microsoft.AspNetCore.Mvc;

namespace BuldingManager.Controllers
{
    [Controller]
    [Route("api/v1/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly ILogger<ExpenseController> _logger;
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService, ILogger<ExpenseController> logger)
        {
            _expenseService = expenseService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseGetDto>>> GetAllExpenses()
        {
            var expenses = await _expenseService.GetExpense();
            if (expenses == null)
            {
                return NotFound();
            }
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseGetDto>> GetExpenseById(int id)
        {
            var expense = await _expenseService.GetExpenseById(id);
            if (expense == null)
            {
                _logger.LogInformation("Expense with id {Id} not found.", id);
                return NotFound();
            }
            return Ok(expense);
        }

        [HttpPost]
        public async Task<ActionResult> CreateExpense([FromBody] ExpenceCreateDto expenseCreateDto)
        {
            var createdExpense = await _expenseService.CreateExpense(expenseCreateDto);
            if (!createdExpense)
            {
                _logger.LogInformation("there is problem Creating Expence");
                return BadRequest("Expense could not be created.");
            }
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExpense(int id, [FromBody] ExpenceCreateDto expenseUpdateDto)
        {
            var updatedExpense = await _expenseService.UpdateExpense(id, expenseUpdateDto);
            if (!updatedExpense)
            {
                _logger.LogInformation("Expense with id {Id} not found for update.", id);
                return NotFound("Expense not found.");
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExpense(int id)
        {
            var deletedExpense = await _expenseService.DeleteExpense(id);
            if (!deletedExpense)
            {
                _logger.LogInformation("Expense with id {Id} not found for deletion.", id);
                return NotFound("Expense not found.");
            }
            return Ok();
        }


    }
}
