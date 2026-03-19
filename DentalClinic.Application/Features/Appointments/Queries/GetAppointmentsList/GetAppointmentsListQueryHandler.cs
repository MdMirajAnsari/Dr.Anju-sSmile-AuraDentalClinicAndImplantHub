using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public class GetAppointmentsListQueryHandler : IRequestHandler<GetAppointmentsListQuery, List<AppointmentsListDTO>>
    {
        private readonly IAppointmentRepository _appointmentsRepository;

        public GetAppointmentsListQueryHandler(IAppointmentRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        public async Task<List<AppointmentsListDTO>> Handle(GetAppointmentsListQuery request)
        {
            var appointments = await _appointmentsRepository.GetFiltered(request);
            var appointmentDTO = appointments.Select(appointments => appointments.ToAppointmentsListDTO()).ToList();
            return appointmentDTO;
        }
    }
}
