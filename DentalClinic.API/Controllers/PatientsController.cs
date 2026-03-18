using DentalClinic.API.DTOs.Patients;
using DentalClinic.API.Utilities;
using DentalClinic.Application.Features.Patients.Commands.CreatePatient;
using DentalClinic.Application.Features.Patients.Commands.DeletePatient;
using DentalClinic.Application.Features.Patients.Commands.UpdatePatient;
using DentalClinic.Application.Features.Patients.Queries.GetPatientDetail;
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
        public async Task<ActionResult<List<PatientListDTO>>> Get([FromQuery] GetPatientsListQuery query)
        {
            var result = await _mediator.Send(query);
            HttpContext.InsertPaginationInformationInHeader(result.TotalAmountOfRecords);
            return result.Elements;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDetailDTO>> Get(Guid id)
        {
            var query = new GetPatientDetailQuery { Id = id };
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, UpdatePatientDTO updatePatientDTO)
        {

            var command = new UpdatePatientCommand { Id = id, Name = updatePatientDTO.Name, Email = updatePatientDTO.Email };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeletePatientCommand { Id = id };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
