using Clinic.Core.DTOs;
using Clinic.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private readonly IDiseaseService _diseaseService;

        public DiseasesController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var diseases = await _diseaseService.GetAllDiseasesAsync();
            return Ok(diseases);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var disease = await _diseaseService.GetDiseaseByIdAsync(id);
            if (disease == null) return NotFound($"Disease with ID {id} not found.");
            return Ok(disease);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDiseaseDto dto)
        {
            var disease = await _diseaseService.AddDiseaseAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = disease.Id }, disease);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateDiseaseDto dto)
        {
            var result = await _diseaseService.UpdateDiseaseAsync(id, dto);
            if (!result) return NotFound($"Disease with ID {id} not found.");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _diseaseService.DeleteDiseaseAsync(id);
            if (!result) return NotFound($"Disease with ID {id} not found.");
            return NoContent();
        }
    }
}
