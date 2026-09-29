using Clinic.Core.DTOs;
using Clinic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        Task<DoctorDto?> GetDoctorByIdAsync(int Id);
        Task<DoctorDto> AddDoctorAsync(CreateDoctorDto dto);
        Task<bool> UpdateDoctorAsync(int id, CreateDoctorDto dto);
        Task<bool> DeleteDoctorAsync(int id);
    }
}
