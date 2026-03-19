using DentalClinic.Application.Contracts.Repositories;
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

        public async Task<bool> OverlapExists(Guid dentistId, DateTime startDate, DateTime endDate)
        {
            return await _context.Appointments.Where(a =>
                a.DentistId == dentistId && a.Status == AppointmentStatus.Scheduled &&
                startDate < a.TimeInterval.End && endDate > a.TimeInterval.Start).AnyAsync();
        }
        
    }
}
