using DentalClinic.API.DTOs.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Notifications
{
    public interface INotifications
    {
        Task SendAppointmentConfirmation(AppointmentConfirmationDTO appointmentConfirmation);
        Task SendAppointmentReminder(AppointmentReminderDTO appointmentReminder);
    }
}
