
using Application.Contracts.Services;
using Application.Dto.Residents;
using Microsoft.AspNetCore.Mvc;

namespace BuldingManager.Controllers
{
    [Controller]
    [Route("api/v1/[controller]")]
    public class ResidentController : ControllerBase
    {
        private readonly IResidentService _residentService;


        [HttpGet]
        public async Task<ActionResult<List<ResidentGetDto>>> GetResidents()
        {
            var residents = await _residentService.GetResidents();
            return Ok(residents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResidentGetDto>> GetResidentById(int id)
        {
            var resident = await _residentService.GetResidentById(id);
            return Ok(resident);

        }

        [HttpPost]
        public async Task<ActionResult> CreateResident([FromBody] ResidentCreateDto residentDto)
        {
            await _residentService.CreateResident(residentDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateResident(int id, [FromBody] ResidentCreateDto residentDto)
        {
            await _residentService.UpdateResident(id, residentDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteResident(int id)
        {
            await _residentService.DeleteResident(id);
            return Ok();
        }



    }
}

