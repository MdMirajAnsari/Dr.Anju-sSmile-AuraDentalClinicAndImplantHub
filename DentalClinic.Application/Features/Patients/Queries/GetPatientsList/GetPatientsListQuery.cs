using DentalClinic.Application.Utilities;
using DentalClinic.Application.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientsListQuery : PatientsFilterDTO, IRequest<PaginatedDTO<PatientListDTO>>
    {

    }

}
