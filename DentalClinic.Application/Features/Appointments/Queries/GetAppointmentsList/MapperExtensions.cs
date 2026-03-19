using DentalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public static class MapperExtensions
    {
        public static AppointmentsListDTO ToAppointmentsListDTO(this Appointment appointment)
        {
            return new AppointmentsListDTO
            {
                Id = appointment.Id,
                Patient = appointment.Patient!.Name,
                Dentist = appointment.Dentist!.Name,
                DentalOffice = appointment.DentalOffice!.Name,
                StartDate = appointment.TimeInterval.Start,
                EndDate = appointment.TimeInterval.End,
                Status = appointment.Status.ToString()
            };
        }
    }
}
