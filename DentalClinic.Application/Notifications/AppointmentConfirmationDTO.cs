using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.API.DTOs.Notifications
{

    public class AppointmentEmailDetaDTO
    {
        public required Guid Id { get; set; }
        public required string Patient { get; set; }
        public required string Patient_Email { get; set; }
        public required string Dentist { get; set; }
        public required string DentalOffice { get; set; }
        public required DateTime Date { get; set; }
    }

    public class AppointmentConfirmationDTO : AppointmentEmailDetaDTO
    {
       
    }

    public class AppointmentReminderDTO : AppointmentEmailDetaDTO
    {

    }
}
