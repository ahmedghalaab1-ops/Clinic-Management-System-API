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
    public class DiseaseService : IDiseaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiseaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DiseaseDto>> GetAllDiseasesAsync()
        {
            var diseases = await _unitOfWork.Diseases.GetAllAsync();
            return diseases.Select(d => new DiseaseDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description
            });
        }

        public async Task<DiseaseDto?> GetDiseaseByIdAsync(int id)
        {
            var disease = await _unitOfWork.Diseases.GetByIdAsync(id);
            if (disease == null) return null;

            return new DiseaseDto
            {
                Id = disease.Id,
                Name = disease.Name,
                Description = disease.Description
            };
        }

        public async Task<DiseaseDto> AddDiseaseAsync(CreateDiseaseDto dto)
        {
            var disease = new Disease
            {
                Name = dto.Name,
                Description = dto.Description
            };

            await _unitOfWork.Diseases.AddAsync(disease);
            await _unitOfWork.CompleteAsync();

            return new DiseaseDto
            {
                Id = disease.Id,
                Name = disease.Name,
                Description = disease.Description
            };
        }

        public async Task<bool> UpdateDiseaseAsync(int id, CreateDiseaseDto dto)
        {
            var disease = await _unitOfWork.Diseases.GetByIdAsync(id);
            if (disease == null) return false;

            disease.Name = dto.Name;
            disease.Description = dto.Description;

            _unitOfWork.Diseases.Update(disease);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<bool> DeleteDiseaseAsync(int id)
        {
            var disease = await _unitOfWork.Diseases.GetByIdAsync(id);
            if (disease == null) return false;

            _unitOfWork.Diseases.Delete(disease);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
