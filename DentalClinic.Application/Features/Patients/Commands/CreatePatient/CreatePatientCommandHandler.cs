using DentalClinic.Application.Contracts.Persistence;
using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Utilities;
using DentalClinic.Domain.Entities;
using DentalClinic.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Patients.Commands.CreatePatient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Guid>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePatientCommandHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
        {
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreatePatientCommand request)
        {
            var email = new Email(request.Email);
            var patient = new Patient(request.Name, email);

            try
            {
                await _patientRepository.AddAsync(patient);
                await _unitOfWork.Commit();
                return patient.Id;

            }
            catch (Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }

        }
    }
}
