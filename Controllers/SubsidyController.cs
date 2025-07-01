using Microsoft.AspNetCore.Mvc;
using NetWares.Dtos;
using NetWares.Interfaces.Service;

namespace NetWares.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubsidyController : ControllerBase
    {
        private readonly ISubsidyService _subsidyService;

        public SubsidyController(ISubsidyService subsidyService)
        {
            _subsidyService = subsidyService;
        }

        // GET: api/Subsidy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadSubsidyDto>>> GetAll()
        {
            var subsidies = await _subsidyService.GetAllAsync();
            return Ok(subsidies);
        }

        // GET: api/Subsidy/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadSubsidyDto>> GetById(int id)
        {
            var subsidy = await _subsidyService.GetByIdAsync(id);
            if (subsidy == null)
                return NotFound();

            return Ok(subsidy);
        }

        // POST: api/Subsidy
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSubsidyDto dto)
        {
            await _subsidyService.AddAsync(dto);
            // Ideally, service returns created entity ID for URI creation
            return CreatedAtAction(nameof(GetById), new { id = 0 }, dto);
        }

        // PUT: api/Subsidy/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateSubsidyDto dto)
        {
            var existingSubsidy = await _subsidyService.GetByIdAsync(id);
            if (existingSubsidy == null)
                return NotFound();

            await _subsidyService.UpdateAsync(dto, id);
            return NoContent();
        }

        // DELETE: api/Subsidy/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingSubsidy = await _subsidyService.GetByIdAsync(id);
            if (existingSubsidy == null)
                return NotFound();

            await _subsidyService.DeleteAsync(id);
            return NoContent();
        }
    }
}
