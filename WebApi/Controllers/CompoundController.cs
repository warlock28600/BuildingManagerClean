
using Application.Contracts.Services;
using Application.Dto.Compound;
using Microsoft.AspNetCore.Mvc;

namespace BuldingManager.Controllers
{
    [Controller]
    [Route("/api/v1/[controller]")]
    public class CompoundController : ControllerBase
    {
        private readonly ILogger<CompoundController> _logger;
        private readonly ICompoundService _compoundService;
        public CompoundController(ILogger<CompoundController> logger, ICompoundService compoundService)
        {
            _logger = logger;
            _compoundService = compoundService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompoundGetDto>>> GetCompound()
        {
            var compounds = await _compoundService.GetCompounds();
            if (compounds == null)
            {
                return NotFound();
            }
            return Ok(compounds);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompoundGetDto>> GetCompoundById(int id)
        {
            var compound = await _compoundService.GetCompoundById(id);
            if (compound == null)
            {
                return NotFound();
            }
            return Ok(compound);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompound([FromBody] CompoundCreateDto compoundCreateDto)
        {
            var result = await _compoundService.CreateCompound(compoundCreateDto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCompound(int id, [FromBody] CompoundCreateDto compoundCreateDto)
        {
            var result = await _compoundService.UpdateCompound(id, compoundCreateDto);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompound(int id)
        {
            var result = await _compoundService.DeleteCompound(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
