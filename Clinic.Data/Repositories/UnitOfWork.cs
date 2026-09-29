using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Core.Repo;
using Clinic.Core.Models;

namespace Clinic.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IDoctorRepository Doctors { get;private set; }
        public IPatientRepository Patients { get;private set; }
        public IDiseaseRepository Diseases { get;private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context; 
            Doctors =  new DoctorRepository(_context);
            Patients = new PatientRepository(_context);
            Diseases = new DiseaseRepository(_context); 
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
