using DentalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Appointments.Queries.GetAppointmentDetail
{
    public static class MapperExtensions
    {
        public static AppointmentDetailDTO ToAppointmentDetailDTO(this Appointment appointment)
        {
            return new AppointmentDetailDTO
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
