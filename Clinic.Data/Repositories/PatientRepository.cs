using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Core.Models;   
using Clinic.Core.Repo;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data.Repositories
{
    public class PatientRepository :GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Patient>> GetPatientsByDoctorIdAsync(int doctorId)
        {
            return await _context.Patients
                .Where(p=> p.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<Patient?> GetPatientWithDiseasesAsync(int patientId)
        {
            return await _context.Patients
                                 .Include(p => p.Diseases)
                                 .FirstOrDefaultAsync(p => p.Id == patientId);
        }
    }
}
