using DentalClinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Appointments.Command.CreateAppointment
{
    public class CreateAppointmentCommand : IRequest<Guid>
    {
        public Guid PatientId { get; set; }
        public Guid DentistId { get; set; }
        public Guid DentalOfficeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
