using DentalClinic.Application.Contracts.Persistence;
using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Exceptions;
using DentalClinic.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.DentalOffices.Commands.CreateDentalOffice
{
    public class CreateDentalOfficeCommandHandler
    {
        private readonly IDentalOfficeRepository _dentalOfficeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateDentalOfficeCommand> _validator;

        public CreateDentalOfficeCommandHandler(IDentalOfficeRepository dentalOfficeRepository, IUnitOfWork unitOfWork, IValidator<CreateDentalOfficeCommand> validator)
        {
            _dentalOfficeRepository = dentalOfficeRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateDentalOfficeCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);
            if (validationResult.IsValid) 
            {
                await _unitOfWork.Rollback();
                throw new CustomValidationException(validationResult);
            }

            var dentalOffice = new DentalOffice(command.Name);

            try
            {
                await _dentalOfficeRepository.AddAsync(dentalOffice);
                await _unitOfWork.Commit();
                return dentalOffice.Id;

            }
            catch (Exception ex) 
            {
                await _unitOfWork.Rollback();
                throw ex;
            }

        }
    }
}
