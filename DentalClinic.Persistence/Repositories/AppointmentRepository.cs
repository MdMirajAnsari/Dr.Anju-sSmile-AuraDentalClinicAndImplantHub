using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Features.Appointments.Queries.GetAppointmentsList;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Persistence.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly DentalClinicDbContext _context;

        public AppointmentRepository(DentalClinicDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<Appointment> GetById(Guid id)
        {
            return _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Dentist)
                .Include(a => a.DentalOffice)
                .FirstOrDefaultAsync(a => a.Id == id)!;
        }

        public async Task<IEnumerable<Appointment>> GetFiltered(AppointmentsFilterDTO appointmentsFilterDTO)
        {
            var queryable = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Dentist)
                .Include(a => a.DentalOffice)
                .AsQueryable();

            if(appointmentsFilterDTO.DentalOfficeId is not null)
            {
                queryable = queryable.Where(a => a.DentalOfficeId == appointmentsFilterDTO.DentalOfficeId);
            }

            if(appointmentsFilterDTO.PatientId is not null)
            {
                queryable = queryable.Where(a => a.PatientId == appointmentsFilterDTO.PatientId);
            }

            if(appointmentsFilterDTO.DentistId is not null)
            {
                queryable = queryable.Where(a => a.DentistId == appointmentsFilterDTO.DentistId);
            }

            return await queryable.Where(a => a.TimeInterval.Start >= appointmentsFilterDTO.StartDate && a.TimeInterval.End <= appointmentsFilterDTO.EndDate)
                .OrderBy(a => a.TimeInterval.Start)
                .ToListAsync();
        }

        public async Task<bool> OverlapExists(Guid dentistId, DateTime startDate, DateTime endDate)
        {
            return await _context.Appointments.Where(a =>
                a.DentistId == dentistId && a.Status == AppointmentStatus.Scheduled &&
                startDate < a.TimeInterval.End && endDate > a.TimeInterval.Start).AnyAsync();
        }
        
    }
}
