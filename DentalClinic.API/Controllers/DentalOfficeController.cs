using DentalClinic.API.DTOs.DentalOffices;
using DentalClinic.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using DentalClinic.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using DentalClinic.Application.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentalOfficeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DentalOfficeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> CreateDentalOffice(CreateDentalOfficeDTO command)
        {
            var result = new CreateDentalOfficeCommand
            {
                Name = command.Name
            };
            await _mediator.Send(result);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DentalOfficeDetailDTO>> GetDentalOffices(Guid id)
        {
            var query = new GetDentalOfficeDetailQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpGet]
        public async Task<ActionResult<List<DentalOfficeDetailDTO>>> GetDentalOffices()
        {
            //var query = new GetDentalOfficesQuery(Id = );
            //var result = await _mediator.Send(query);
            //return Ok(result);
            return Ok();
        }
    }
}
