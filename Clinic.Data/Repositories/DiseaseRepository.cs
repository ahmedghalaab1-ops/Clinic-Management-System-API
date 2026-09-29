using Clinic.Core.Models;
using Clinic.Core.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Data.Repositories
{
    public class DiseaseRepository:GenericRepository<Disease>,IDiseaseRepository
    {
        public DiseaseRepository(AppDbContext context) :base(context)
        {
        }
    }
}
