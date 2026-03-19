using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Exceptions;
using DentalClinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Appointments.Queries.GetAppointmentDetail
{
    public class GetAppointmentDetailQueryHandler : IRequestHandler<GetAppointmentDetailQuery, AppointmentDetailDTO>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAppointmentDetailQueryHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<AppointmentDetailDTO> Handle(GetAppointmentDetailQuery request)
        {
            var appointment = await _appointmentRepository.GetById(request.Id);

            if (appointment == null) 
            {
                throw new NotFoundException();
            }

            return appointment.ToAppointmentDetailDTO();
        }
    }
}
