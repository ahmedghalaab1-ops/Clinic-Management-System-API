using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Core.Repo;

namespace Clinic.Core.Repo
{
    public interface IUnitOfWork : IDisposable
    {
        IDoctorRepository Doctors { get; }
        IPatientRepository Patients { get; }
        IDiseaseRepository Diseases { get; }

        Task<int> CompleteAsync();
    }
}
