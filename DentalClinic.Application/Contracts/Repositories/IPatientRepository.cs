using DentalClinic.Application.Features.Patients.Queries.GetPatientsList;
using DentalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Contracts.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetFiltered(PatientsFilterDTO patientsFilterDTO);
    }
}
