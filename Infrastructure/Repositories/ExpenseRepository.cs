using Application.Contracts.Repositories;
using AutoMapper;
using BuldingManager.ApplicationDbContext;
using Domain.Entities;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly BuildingDbContext _context;
        private readonly IMapper _mapper;

        public ExpenseRepository(BuildingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateExpenseAsync(Expense expense)
        {
            await _context.AddAsync(expense);
            var created = await _context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> DeleteExpenseAsync(int id)
        {
            var expense =  await GetExpenseByIdAsync(id);
            if (expense == null)
            {
                return false;
            }
            _context.Expenses.Remove(expense);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<Expense?> GetExpenseByIdAsync(int id)
        {
            var expense = await _context.Expenses.FirstOrDefaultAsync(e=>e.Id==id);
            return expense;
        }

        public async Task<IEnumerable<Expense>> GetExpensesAsync()
        {
            var expenses =await  _context.Expenses.ToListAsync();
            return expenses;
        }

        public async Task<bool> UpdateExpenseAsync(int id, Expense expense)
        {
            var existingExpense =  await GetExpenseByIdAsync(id);
            if (existingExpense == null)
            {
                return false;
            }
            _mapper.Map(expense, existingExpense);
            var updated = await _context.SaveChangesAsync();
            return updated > 0;
        }
    }
}
