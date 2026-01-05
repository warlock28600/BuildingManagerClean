using Application.Contracts.Services;
using Application.Dto.UnitExpense;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UnitExpenseController:ControllerBase
{
    #region Constructor 
    private readonly IUnitExpenseService _unitExpenseService;

    public UnitExpenseController(IUnitExpenseService unitExpenseService)
    {
        _unitExpenseService = unitExpenseService;
    }

    #endregion

    #region Get Methods
    [HttpGet]
    public async Task<IEnumerable<UnitExpenseGetDto>> GetUnitExpenses()
    {
        var unitExpenses = await _unitExpenseService.getAll();
        return unitExpenses;
    }

    [HttpGet("{id}")]
    public async Task<UnitExpenseGetDto> GetUnitExpense(int id)
    {
        var unitExpense = await _unitExpenseService.getById(id);
        return unitExpense;
    }
    #endregion
    
    #region Create Methods
    [HttpPost]
    public async Task<bool> CreateUnitExpanse([FromBody] UnitExpenseCreateDto unitExpenseCreateDto)
    {
        var created = await _unitExpenseService.CreateUnitExpanse(unitExpenseCreateDto);
        return created;
    }
    #endregion
    
    #region Update Methods
    [HttpPut("{id}")]
    public async Task<bool> DeleteUnitExpanse(int id,UnitExpenseCreateDto  unitExpenseCreateDto)
    {
     var updated = await _unitExpenseService.UpdateUnitExpanse(id,unitExpenseCreateDto);
     return updated;
    }
    #endregion
    
    #region Delete Methods
    [HttpDelete("{id}")]
    public async Task<bool> DeleteUnitExpanse(int id)
    {
        var deleted = await _unitExpenseService.DeleteUnitExpanse(id);
        return deleted;
    }
    #endregion
    
}