using DentalClinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Patients.Queries.GetPatientDetail
{
    public class GetPatientDetailQuery : IRequest<PatientDetailDTO>
    {
        public required Guid Id { get; set; }
    }
}
