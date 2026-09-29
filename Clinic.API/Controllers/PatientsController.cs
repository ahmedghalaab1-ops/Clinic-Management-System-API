using Clinic.Core.DTOs;
using Clinic.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null) return NotFound($"Patient with ID {id} not found.");
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePatientDto dto)
        {
            var patient = await _patientService.AddPatientAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreatePatientDto dto)
        {
            var result = await _patientService.UpdatePatientAsync(id, dto);
            if (!result) return NotFound($"Patient with ID {id} not found.");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _patientService.DeletePatientAsync(id);
            if (!result) return NotFound($"Patient with ID {id} not found.");
            return NoContent();
        }

        [HttpPost("{patientId}/diseases/{diseaseId}")]
        public async Task<IActionResult> AssignDisease(int patientId, int diseaseId)
        {
            var result = await _patientService.AssignDiseaseToPatientAsync(patientId, diseaseId);
            if (!result) return NotFound("إما المريض أو المرض غير موجود.");

            return Ok(new { message = "تم إسناد المرض للمريض بنجاح." });
        }

        [HttpGet("{patientId}/diseases")]
        public async Task<IActionResult> GetPatientDiseases(int patientId)
        {
            var diseases = await _patientService.GetPatientDiseasesAsync(patientId);
            if (diseases == null) return NotFound($"المريض صاحب الرقم {patientId} غير موجود.");

            return Ok(diseases);
        }
    }
}
