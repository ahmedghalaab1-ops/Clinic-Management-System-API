using Clinic.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task<PatientDto?> GetPatientByIdAsync(int id);
        Task<PatientDto> AddPatientAsync(CreatePatientDto dto);
        Task<bool> UpdatePatientAsync(int id, CreatePatientDto dto);
        Task<bool> DeletePatientAsync(int id);

        Task<bool> AssignDiseaseToPatientAsync(int patientId, int diseaseId);
        Task<IEnumerable<DiseaseDto>?> GetPatientDiseasesAsync(int patientId);
    }
}
