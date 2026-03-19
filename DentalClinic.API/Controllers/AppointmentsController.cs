using DentalClinic.API.DTOs.Appointments;
using DentalClinic.Application.Features.Appointments.Command.CreateAppointment;
using DentalClinic.Application.Features.Appointments.Queries.GetAppointmentDetail;
using DentalClinic.Application.Features.Appointments.Queries.GetAppointmentsList;
using DentalClinic.Application.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(Guid id)
        {
            var query = new GetAppointmentDetailQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments([FromQuery] GetAppointmentsListQuery getAppointmentsListQuery)
        {
            return await _mediator.Send(getAppointmentsListQuery) is List<AppointmentsListDTO> appointments
                ? Ok(appointments)
                : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentDTO createAppointmentDTO)
        {
            var command = new CreateAppointmentCommand
            {
                PatientId = createAppointmentDTO.PatientId,
                DentistId = createAppointmentDTO.DentistId,
                DentalOfficeId = createAppointmentDTO.DentalOfficeId,
                StartDate = createAppointmentDTO.StartDate,
                EndDate = createAppointmentDTO.EndDate
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
