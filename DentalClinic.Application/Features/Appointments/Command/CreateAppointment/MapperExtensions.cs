using DentalClinic.API.DTOs.Notifications;
using DentalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Appointments.Command.CreateAppointment
{
    public static class MapperExtensions
    {
        public static AppointmentConfirmationDTO ToAppointment(this Appointment appointment)
        {
            return new AppointmentConfirmationDTO
            {
                Id = appointment.Id,
                Patient = appointment.Patient!.Name,
                Dentist = appointment.Dentist!.Name,
                DentalOffice = appointment.DentalOffice!.Name,
                Patient_Email = appointment.Patient.Email.Value,
                Date = appointment.TimeInterval.Start

            };
        }
    }
}
