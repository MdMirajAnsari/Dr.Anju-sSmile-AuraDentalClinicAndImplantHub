using DentalClinic.Application.Contracts.Persistence;
using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Exceptions;
using DentalClinic.Application.Utilities;
using DentalClinic.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPatientRepository _patientRepository;

        public UpdatePatientCommandHandler(IUnitOfWork unitOfWork, IPatientRepository patientRepository)
        {
            _unitOfWork = unitOfWork;
            _patientRepository = patientRepository;
        }

        public async Task Handle(UpdatePatientCommand request)
        {
            var patient = _patientRepository.GetByIdAsync(request.Id).Result;

            if (patient == null) 
            {
                throw new NotFoundException();
            }

            patient.UpdateName(request.Name);
            var email = new Email(request.Email);
            patient.UpdateEmail(email);

            try
            {
                await _patientRepository.UpdateAsync(patient);
                await _unitOfWork.Commit();
            }
            catch (Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
