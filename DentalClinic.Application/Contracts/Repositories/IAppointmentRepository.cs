using DentalClinic.Application.Features.Appointments.Queries.GetAppointmentsList;
using DentalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Contracts.Repositories
{
    public interface IAppointmentRepository :IRepository<Appointment>
    {
        Task<bool> OverlapExists(Guid dentistId, DateTime startDate, DateTime endDate);
        new Task<Appointment> GetById(Guid id);
        Task<IEnumerable<Appointment>> GetFiltered(AppointmentsFilterDTO appointmentsFilterDTO);
    }
}
