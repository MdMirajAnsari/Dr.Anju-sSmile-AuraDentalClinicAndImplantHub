using DentalClinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Patients.Commands.CreatePatient
{
    public class CreatePatientCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required string Email { get; set; }

    }
}
