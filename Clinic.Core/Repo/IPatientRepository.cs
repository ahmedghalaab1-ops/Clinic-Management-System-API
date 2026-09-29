using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Core.Models;

namespace Clinic.Core.Repo
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetPatientsByDoctorIdAsync(int doctorId);
        Task<Patient?> GetPatientWithDiseasesAsync(int patientId);
    }
}
