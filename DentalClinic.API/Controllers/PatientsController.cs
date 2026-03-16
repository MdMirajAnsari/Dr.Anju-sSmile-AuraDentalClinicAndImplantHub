using DentalClinic.API.DTOs.Patients;
using DentalClinic.Application.Features.Patients.Commands.CreatePatient;
using DentalClinic.Application.Features.Patients.Queries.GetPatientsList;
using DentalClinic.Application.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreatePatientDTO createPatientDTO)
        {
            var command = new CreatePatientCommand { Name = createPatientDTO.Name, Email = createPatientDTO.Email };

            await _mediator.Send(command);
            return Ok();

        }

        [HttpGet]
        public async Task<ActionResult<List<PatientListDTO>>> Get()
        {
            var query = new GetPatientsListQuery();
            var patients = await _mediator.Send(query);
            return Ok(patients);
        }
    }
}
