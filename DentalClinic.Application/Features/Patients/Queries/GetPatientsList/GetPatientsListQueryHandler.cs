using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Patients.Queries.GetPatientsList
{
    public class GetPatientsListQueryHandler : IRequestHandler<GetPatientsListQuery, List<PatientListDTO>>
    {
        private readonly IPatientRepository _patientRepository;
        public GetPatientsListQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<List<PatientListDTO>> Handle(GetPatientsListQuery request)
        {
            var patients = await _patientRepository.GetAllAsync();
            var patientDTO = patients.Select(p => new PatientListDTO
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email?.ToString()
            }).ToList();
            return patientDTO;


        }
    }
}
