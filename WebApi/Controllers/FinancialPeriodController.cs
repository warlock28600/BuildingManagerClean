
using Application.Contracts.Services;
using Application.Dto.FinancialPeriod;
using BuldingManager.Services.FinancialPeriod;
using Microsoft.AspNetCore.Mvc;

namespace BuldingManager.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FinancialPeriodController : ControllerBase
    {

        private readonly IFinancialPeriodService _financialPeriodService;

        public FinancialPeriodController(IFinancialPeriodService financialPeriodService)
        {
            _financialPeriodService = financialPeriodService;

        }

        [HttpPost()]
        public async Task<IActionResult> CreateFinancialPeriod(FinancialPeriodCreateDto dto)
        {
            var result = await _financialPeriodService.CreateFinancialPeriod(dto);
            return Ok(result);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFinancialPeriod([FromQuery] int id)
        {
            var result = await _financialPeriodService.DeleteFinancialPeriod(id);
            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllFinancialPeriods()
        {
            var result = await _financialPeriodService.GetFinancialPeriods();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFinancialPeriodById(int id)
        {
            var result = await _financialPeriodService.GetFinancialPeriodById(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CloseFinancialPeriod( int id)
        {
            var result = await _financialPeriodService.DeleteFinancialPeriod(id);
            return Ok(result);
        }

    }
}
