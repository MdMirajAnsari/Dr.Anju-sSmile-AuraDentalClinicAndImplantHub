using DentalClinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public class GetAppointmentsListQuery : AppointmentsFilterDTO, IRequest<List<AppointmentsListDTO>>
    {

    }
}
