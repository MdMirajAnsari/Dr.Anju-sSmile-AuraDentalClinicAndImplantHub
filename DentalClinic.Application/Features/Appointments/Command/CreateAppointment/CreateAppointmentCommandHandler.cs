using DentalClinic.API.DTOs.Notifications;
using DentalClinic.Application.Contracts.Persistence;
using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Exceptions;
using DentalClinic.Application.Features.Appointments.Queries.GetAppointmentDetail;
using DentalClinic.Application.Notifications;
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
        private readonly INotifications _notifications;

        public CreateAppointmentCommandHandler(IUnitOfWork unitOfWork, IAppointmentRepository appointmentRepository, INotifications notifications)
        {
            _unitOfWork = unitOfWork;
            _appointmentRepository = appointmentRepository;
            _notifications = notifications;
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

            Guid? id = null;

            try
            {
                var result = _appointmentRepository.AddAsync(appointment);
                await _unitOfWork.Commit();
                id= appointment.Id;
            }
            catch (Exception)
            {

                await _unitOfWork.Rollback();
                throw;
            }

            var appointmentDb = await _appointmentRepository.GetByIdAsync(id.Value);
            var detailDTO = appointmentDb.ToAppointmentDetailDTO();

            var notificationDTO = new AppointmentConfirmationDTO
            {
                Id = detailDTO.Id,
                Patient = detailDTO.Patient,
                Patient_Email = detailDTO.Patient,
                Dentist = detailDTO.Dentist,
                DentalOffice = detailDTO.DentalOffice,
                Date = detailDTO.StartDate
            };

            await _notifications.SendAppointmentConfirmation(notificationDTO);
            return id.Value;
        }
    }
}
