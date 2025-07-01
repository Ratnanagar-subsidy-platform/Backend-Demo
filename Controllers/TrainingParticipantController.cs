using Microsoft.AspNetCore.Mvc;
using NetWares.DTOs;
using NetWares.Interfaces.Service;

namespace NetWares.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingParticipantController : ControllerBase
    {
        private readonly ITrainingParticipantService _trainingParticipantService;

        public TrainingParticipantController(ITrainingParticipantService trainingParticipantService)
        {
            _trainingParticipantService = trainingParticipantService;
        }

        // GET: api/TrainingParticipant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadTrainingParticipantDto>>> GetAll()
        {
            var participants = await _trainingParticipantService.GetAllAsync();
            return Ok(participants);
        }

        // GET: api/TrainingParticipant/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadTrainingParticipantDto>> GetById(int id)
        {
            var participant = await _trainingParticipantService.GetByIdAsync(id);
            if (participant == null)
                return NotFound();

            return Ok(participant);
        }

        // POST: api/TrainingParticipant
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTrainingParticipantDto dto)
        {
            await _trainingParticipantService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = /* assume id here? */ 0 }, dto);
            // Note: Ideally, service returns created entity with ID, adjust accordingly.
        }

        // PUT: api/TrainingParticipant/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateTrainingParticipantDto dto)
        {
            var existingParticipant = await _trainingParticipantService.GetByIdAsync(id);
            if (existingParticipant == null)
                return NotFound();

            await _trainingParticipantService.UpdateAsync(dto, id);
            return NoContent();
        }

        // DELETE: api/TrainingParticipant/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingParticipant = await _trainingParticipantService.GetByIdAsync(id);
            if (existingParticipant == null)
                return NotFound();

            await _trainingParticipantService.DeleteAsync(id);
            return NoContent();
        }
    }
}
