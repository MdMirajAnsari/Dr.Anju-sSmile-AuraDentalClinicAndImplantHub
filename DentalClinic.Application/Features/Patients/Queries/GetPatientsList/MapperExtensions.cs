using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Patients.Queries.GetPatientsList
{
    public static class MapperExtensions
    {
        public static PatientListDTO ToPatientListDTO(this Domain.Entities.Patient patient)
        {
            return new PatientListDTO
            {
                Id = patient.Id,
                Name = patient.Name,
                Email = patient.Email.Value,
            };
        }
    }
}
