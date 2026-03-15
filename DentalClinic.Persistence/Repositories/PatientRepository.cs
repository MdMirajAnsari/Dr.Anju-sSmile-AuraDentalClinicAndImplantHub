using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Persistence.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(DentalClinicDbContext context) : base(context)
        {
            
        }

    }
}
