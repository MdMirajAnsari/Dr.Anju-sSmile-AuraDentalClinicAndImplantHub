using DentalClinic.API.DTOs.Notifications;
using DentalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Appointments.Command.SendAppointmentReminder
{
    public static class MapperExtensions
    {
        public static AppointmentReminderDTO toDto(this Appointment dto) 
        {
            return new AppointmentReminderDTO
            {
                Id = dto.Id,
                Date = dto.TimeInterval.Start,
                Patient= dto.Patient!.Name,
                Patient_Email = dto.Patient!.Email.Value,
                Dentist = dto.Dentist!.Name,
                DentalOffice = dto.DentalOffice!.Name,
            };
        }
    }
}
