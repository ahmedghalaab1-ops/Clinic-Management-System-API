using Clinic.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Services
{
    public interface IDiseaseService
    {
        Task<IEnumerable<DiseaseDto>> GetAllDiseasesAsync();
        Task<DiseaseDto?> GetDiseaseByIdAsync(int id);
        Task<DiseaseDto> AddDiseaseAsync(CreateDiseaseDto dto);
        Task<bool> UpdateDiseaseAsync(int id, CreateDiseaseDto dto);
        Task<bool> DeleteDiseaseAsync(int id);  
    }
}
