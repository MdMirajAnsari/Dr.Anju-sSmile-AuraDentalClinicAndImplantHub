using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Exceptions;
using DentalClinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Patients.Queries.GetPatientDetail
{
    public class GetPatientDetailQueryHandler : IRequestHandler<GetPatientDetailQuery, PatientDetailDTO>
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientDetailQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PatientDetailDTO> Handle(GetPatientDetailQuery request)
        {
            var patient = await _patientRepository.GetByIdAsync(request.Id);

            if (patient == null) 
            {
                throw new NotFoundException();
            }
            return patient.ToPatientDetailDTO();
        }
    }
}
