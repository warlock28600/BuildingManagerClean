using Application.Contracts.Services;
using Application.Dto.Attribute;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;

namespace BuldingManager.Controllers
{
    [Controller]
    [Route("api/v1/[controller]")]
    public class AttributeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAttributeService _service;
        private readonly ILogger<AttributeController> _logger;
        public AttributeController(IMapper mapper, IAttributeService service, ILogger<AttributeController> logger)
        {
            _mapper = mapper;
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<AttributeGetDto>>> GetAttribute()
        {
            var attributes =  await _service.GetAttributes();
            if (attributes==null)
            {
                return NotFound();  
            }
            return Ok(attributes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttributeGetDto>> GetAttribute(int id)
        {
            var attribute = await _service.GetAttribute(id);
            if (attribute==null)
            {
                return NotFound();  
            }
            return Ok(attribute);
        }

        [HttpPost]
        public async Task<ActionResult> PostAttribute([FromBody] attributeCreateDto attribute)
        {
            var created = await _service.CreateAttribute(attribute);
            if (!created)
            {
                _logger.LogError("there is problem creating attribute");
                return BadRequest("there is problem creating attribute");
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAttribute(int id,[FromBody] attributeCreateDto attribute)
        {
            var updated= await _service.UpdateAttribute(id, attribute);
            if (!updated)
            {
                _logger.LogError("there is problem updating attribute");
                return BadRequest("there is problem updating attribute");
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAttribute(int id)
        {
            var deleted= await _service.DeleteAttribute(id);
            if (!deleted)
            {
                _logger.LogError("there is problem deleting attribute");
                return BadRequest("there is problem deleting attribute");
            }
            return Ok();
        }


    }
}
