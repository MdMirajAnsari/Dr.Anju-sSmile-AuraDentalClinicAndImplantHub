using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Features.Appointments.Queries.GetAppointmentsList;
using DentalClinic.Application.Notifications;
using DentalClinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Appointments.Command.SendAppointmentReminder
{
    public class SendAppointmentReminderCommandHandler : IRequestHandler<SendAppointmentReminderCommand>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly INotifications _notifications;

        public SendAppointmentReminderCommandHandler(IAppointmentRepository appointmentRepository, INotifications notifications)
        {
            _appointmentRepository = appointmentRepository;
            _notifications = notifications;
        }

        public async Task Handle(SendAppointmentReminderCommand request)
        {
            var startDate = DateTime.Now.AddDays(1);
            var endDate = startDate.AddDays(1);
            var filter = new AppointmentsFilterDTO
            {
                StartDate = startDate,
                EndDate = endDate,

            };

            var appointments = await _appointmentRepository.GetFiltered(filter);

            foreach (var appointment in appointments)
            {
                var dto = appointment.toDto();
                await _notifications.SendAppointmentReminder(dto);
            }
        }
    }
}
