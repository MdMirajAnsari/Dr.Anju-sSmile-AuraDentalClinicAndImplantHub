using DentalClinic.Application.Contracts.Persistence;
using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Exceptions;
using DentalClinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Appointments.Command.CancelAppointment
{
    public class CancelAppointmentCommandHandler : IRequestHandler<CancelAppointmentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppointmentRepository _appointmentRepository;

        public CancelAppointmentCommandHandler(IUnitOfWork unitOfWork, IAppointmentRepository appointmentRepository)
        {
            _unitOfWork = unitOfWork;
            _appointmentRepository = appointmentRepository;
        }

        public async Task Handle(CancelAppointmentCommand request)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(request.Id);

            if (appointment == null) 
            {
                throw new NotFoundException();
            }

            appointment.Cancel();

            try
            {
                await _appointmentRepository.UpdateAsync(appointment);
                await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
