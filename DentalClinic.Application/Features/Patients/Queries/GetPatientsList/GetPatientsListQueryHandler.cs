using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Utilities;
using DentalClinic.Application.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientsListQueryHandler : IRequestHandler<GetPatientsListQuery, PaginatedDTO<PatientListDTO>>
    {
        private readonly IPatientRepository _patientRepository;
        public GetPatientsListQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<PaginatedDTO<PatientListDTO>> Handle(GetPatientsListQuery request)
        {
            var patients = await _patientRepository.GetFiltered(request);
            var totalAmountOfRecords = await _patientRepository.GetTotalAmountOfRecords();
            var patientsDTO= patients.Select(p => new PatientListDTO
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email.Value,
            }).ToList();

            var paginatedDTO = new PaginatedDTO<PatientListDTO>
            {
                Elements = patientsDTO,
                TotalAmountOfRecords = totalAmountOfRecords
            };

            return paginatedDTO;


        }
    }
}
