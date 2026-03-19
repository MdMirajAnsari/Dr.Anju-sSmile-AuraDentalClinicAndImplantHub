using DentalClinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Appointments.Command.CompleteAppointment
{
    public class CompleteAppointmentCommand : IRequest<Guid>
    {
        public required Guid Id { get; set; }
    }
}
