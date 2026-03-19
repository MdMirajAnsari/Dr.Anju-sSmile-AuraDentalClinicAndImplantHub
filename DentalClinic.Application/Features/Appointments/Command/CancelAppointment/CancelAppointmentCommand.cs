using DentalClinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Appointments.Command.CancelAppointment
{
    public class CancelAppointmentCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
