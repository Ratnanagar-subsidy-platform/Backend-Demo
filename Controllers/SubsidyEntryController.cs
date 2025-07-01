using Microsoft.AspNetCore.Mvc;
using NetWares.DTOs;
using NetWares.Interfaces.Service;


namespace NetWares.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubsidyEntryController : ControllerBase
    {
        private readonly ISubsidyEntryService _subsidyEntryService;

        public SubsidyEntryController(ISubsidyEntryService subsidyEntryService)
        {
            _subsidyEntryService = subsidyEntryService;
        }

        // GET: api/SubsidyEntry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadSubsidyEntryDto>>> GetAll()
        {
            var entries = await _subsidyEntryService.GetAllAsync();
            return Ok(entries);
        }

        // GET: api/SubsidyEntry/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadSubsidyEntryDto>> GetById(int id)
        {
            var entry = await _subsidyEntryService.GetByIdAsync(id);
            if (entry == null)
                return NotFound();

            return Ok(entry);
        }

        // POST: api/SubsidyEntry
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateSubsidyEntryDto dto)
        {
            await _subsidyEntryService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, dto);
            // Ideally return created entity id here instead of 0
        }

        // PUT: api/SubsidyEntry/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateSubsidyEntryDto dto)
        {
            var existingEntry = await _subsidyEntryService.GetByIdAsync(id);
            if (existingEntry == null)
                return NotFound();

            await _subsidyEntryService.UpdateAsync(dto, id);
            return NoContent();
        }

        // DELETE: api/SubsidyEntry/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingEntry = await _subsidyEntryService.GetByIdAsync(id);
            if (existingEntry == null)
                return NotFound();

            await _subsidyEntryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
