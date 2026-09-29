using Clinic.Core.DTOs;
using Clinic.Core.Models;
using Clinic.Core.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _unitOfWork.Patients.GetAllAsync();
            var dtos = new List<PatientDto>();

            foreach (var p in patients)
            {
                var doctor = await _unitOfWork.Doctors.GetByIdAsync(p.DoctorId);
                dtos.Add(new PatientDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Age = p.Age,
                    Phone = p.PhoneNumber,
                    DoctorId = p.DoctorId,
                    DoctorName = doctor?.Name ?? "N/A"
                });
            }

            return dtos;
        }

        public async Task<PatientDto?> GetPatientByIdAsync(int id)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);
            if (patient == null) return null;

            var doctor = await _unitOfWork.Doctors.GetByIdAsync(patient.DoctorId);

            return new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                Age = patient.Age,
                Phone = patient.PhoneNumber,
                DoctorId = patient.DoctorId,
                DoctorName = doctor?.Name ?? "N/A"
            };
        }

        public async Task<PatientDto> AddPatientAsync(CreatePatientDto dto)
        {
            var patient = new Patient
            {
                Name = dto.Name,
                Age = dto.Age,
                PhoneNumber = dto.Phone,
                DoctorId = dto.DoctorId
            };

            await _unitOfWork.Patients.AddAsync(patient);
            await _unitOfWork.CompleteAsync();

            return new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                Age = patient.Age,
                Phone = patient.PhoneNumber,
                DoctorId = patient.DoctorId
            };
        }

        public async Task<bool> UpdatePatientAsync(int id, CreatePatientDto dto)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);
            if (patient == null) return false;

            patient.Name = dto.Name;
            patient.Age = dto.Age;
            patient.PhoneNumber = dto.Phone;
            patient.DoctorId = dto.DoctorId;

            _unitOfWork.Patients.Update(patient);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);
            if (patient == null) return false;

            _unitOfWork.Patients.Delete(patient);
            await _unitOfWork.CompleteAsync();

            return true;
        }


        public async Task<bool> AssignDiseaseToPatientAsync(int patientId, int diseaseId)
        {
            // 1. التأكد من وجود المريض مع تحميل أمراضه
            var patient = await _unitOfWork.Patients.GetPatientWithDiseasesAsync(patientId);
            if (patient == null) return false;

            // 2. التأكد من وجود المرض
            var disease = await _unitOfWork.Diseases.GetByIdAsync(diseaseId);
            if (disease == null) return false;

            // 3. منع تكرار إضافة نفس المرض للمريض
            if (patient.Diseases.Any(d => d.Id == diseaseId)) return true;

            // 4. ربط المرض بالمريض وحفظ التغيرات
            patient.Diseases.Add(disease);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<IEnumerable<DiseaseDto>?> GetPatientDiseasesAsync(int patientId)
        {
            var patient = await _unitOfWork.Patients.GetPatientWithDiseasesAsync(patientId);
            if (patient == null) return null;

            return patient.Diseases.Select(d => new DiseaseDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description
            });
        }
    }
}
