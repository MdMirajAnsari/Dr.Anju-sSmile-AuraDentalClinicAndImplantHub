using DentalClinic.Application.Contracts.Persistence;
using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Exceptions;
using DentalClinic.Application.Utilities;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Appointments.Command.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppointmentRepository _appointmentRepository;

        public CreateAppointmentCommandHandler(IUnitOfWork unitOfWork, IAppointmentRepository appointmentRepository)
        {
            _unitOfWork = unitOfWork;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Guid> Handle(CreateAppointmentCommand request)
        {
            var existingOverlap = await _appointmentRepository.OverlapExists(request.DentistId, request.StartDate, request.EndDate);

            if (existingOverlap)
            {
                throw new Exception("The dentist has an overlapping appointment during the specified time.");
            }

            var timeInterval = new TimeInterval(request.StartDate, request.EndDate);
            var appointment = new Appointment(request.PatientId, request.DentistId, request.DentalOfficeId, timeInterval);

            try
            {
                var result = _appointmentRepository.AddAsync(appointment);
                await _unitOfWork.Commit();
                return appointment.Id;
            }
            catch (Exception)
            {

                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
