using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Patients.Queries.GetPatientDetail
{
    public static class MapperExtensions
    {
        public static PatientDetailDTO ToPatientDetailDTO(this Domain.Entities.Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));
            return new PatientDetailDTO
            {
                Id = patient.Id,
                Name = patient.Name,
                Email = patient.Email.Value,
            };
        }
    }
}
