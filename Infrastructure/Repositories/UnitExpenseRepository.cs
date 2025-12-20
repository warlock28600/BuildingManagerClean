using Application.Contracts.Repositories;
using AutoMapper;
using Domain.Entities;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;

public class UnitExpenseRepository:IUnitExpenseRepository
{
    #region Constructor
    private readonly BuildingDbContext  _context;
    private readonly ILogger<UnitExpenseRepository> _logger;
    private readonly IMapper _mapper;

    public UnitExpenseRepository(BuildingDbContext context, ILogger<UnitExpenseRepository> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }
    #endregion

    #region Get Methods
    public async Task<IEnumerable<UnitExpense>> GetAll()
    {
        var expenses = await _context.UnitExpenses.ToListAsync();
        return expenses;
    }
    
    public async Task<UnitExpense> Get(int id)
    {
        var expense = await _context.UnitExpenses.FirstOrDefaultAsync(u=>u.Id == id);
        return expense;
    }
    
    #endregion 
    
    #region Create Method
    public async Task<bool> Add(UnitExpense unitExpense)
    {
        _context.UnitExpenses.Add(unitExpense);
        var created = await _context.SaveChangesAsync();
        return created > 0;
    }
    #endregion

    #region Update Method
    public async Task<bool> Update(int id, UnitExpense unitExpense)
    {
        var unitExpenseToUpdate = await Get(id);
        if (unitExpenseToUpdate == null)
        {
            _logger.LogInformation("there's nothing to update");
            return false;
        }
        _mapper.Map(unitExpenseToUpdate, unitExpense);
        var updated = await _context.SaveChangesAsync();
        return updated > 0;
    }
    #endregion
    
    #region Delete Method
    public async Task<bool> Delete(int id)
    {
        var unitExpenseToDelete = await Get(id);
        if (unitExpenseToDelete == null)
        {
            _logger.LogInformation("there's nothing to update");
            return false;
        }
        _context.UnitExpenses.Remove(unitExpenseToDelete);
        var deleted = await _context.SaveChangesAsync();
        return deleted > 0;
    }
    #endregion
}