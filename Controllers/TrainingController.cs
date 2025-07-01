using Microsoft.AspNetCore.Mvc;
using NetWares.DTOs;
using NetWares.Interfaces.Service;

namespace NetWares.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadTrainingDto>>> GetAll()
        {
            var trainings = await _trainingService.GetAllAsync();
            return Ok(trainings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadTrainingDto>> GetById(int id)
        {
            var training = await _trainingService.GetByIdAsync(id);
            if (training == null) return NotFound();
            return Ok(training);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateTrainingDto createDto)
        {
            await _trainingService.AddAsync(createDto);
            // Ideally return the URI of created resource
            return CreatedAtAction(nameof(GetById), new { id = 0 }, null); 
            // Replace '0' with actual id if available after creation
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTrainingDto updateDto)
        {
            if (id != updateDto.Id)
                return BadRequest("ID mismatch");

            await _trainingService.UpdateAsync(updateDto, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _trainingService.DeleteAsync(id);
            return NoContent();
        }
    }
}
