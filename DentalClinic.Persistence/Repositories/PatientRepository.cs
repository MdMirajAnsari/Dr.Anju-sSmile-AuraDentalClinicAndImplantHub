using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Features.Patients.Queries.GetPatientsList;
using DentalClinic.Domain.Entities;
using DentalClinic.Persistence.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Persistence.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly DentalClinicDbContext _context;

        public PatientRepository(DentalClinicDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Patient>> GetFiltered(PatientsFilterDTO patientsFilterDTO)
        {
            return await _context.Patients.OrderBy(_=>_.Name)
                .Paginate(patientsFilterDTO.Page, patientsFilterDTO.RecordsPerPage)
                .ToListAsync();
        }
    }
}
