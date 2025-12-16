
using Application.Contracts.Services;
using Application.Dto.AttributeType;
using BuldingManager.Services.AttributeType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace BuldingManager.Controllers
{
    [Controller]
    [Route("api/v1/[controller]")]
    public class AttributeTypeController : ControllerBase
    {
        private readonly IAttributeTypeService _service;
        private readonly ILogger<AttributeTypeController> _logger;

        public AttributeTypeController(IAttributeTypeService service, ILogger<AttributeTypeController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttributeTypeGetDto>>> GetAttributeTypes()
        {
            var attributeTypes = await _service.GetAttributeTypes();
            return Ok(attributeTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttributeTypeGetDto>> GetAttributeType(int id)
        {
            var attributeType = await _service.GetAttributeType(id);
            if (attributeType == null)
            {
                return NotFound();
            }
            return Ok(attributeType);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAttributeType([FromBody] AttributeTypeCreateAndUpdateDto attributeType)
        {
            var created = await _service.CreateAttributeType(attributeType);
            if (!created)
            {
                _logger.LogError("there id problem creating attribute type");
                return BadRequest("there id problem creating attribute type");
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAttributeType(int id, [FromBody] AttributeTypeCreateAndUpdateDto attributeType)
        {
         var updated =  await _service.UpdateAttributeType(id, attributeType);
            if (!updated)
            {
                _logger.LogError("there is problem updating AttributeType");
                return BadRequest("there is problem updating AttributeType");
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAttributeType(int id)
        {
            var deleted = await _service.DeleteAttributeType(id);
            if (!deleted)
            {
                _logger.LogError("there is problem deleting AttributeType");
                return BadRequest("there is problem deleting AttributeType");
            }
            return Ok();
        }

    }
}
