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
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecializationAsync(string specialization)
        {
            return await _context.Doctors
                .Where(d=> d.Specialty == specialization)
                .ToListAsync();
        }
    }
}
