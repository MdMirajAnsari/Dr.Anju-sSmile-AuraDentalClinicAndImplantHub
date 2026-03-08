using DentalClinic.Application.Contracts.Persistence;
using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Exceptions;
using DentalClinic.Application.Utilities;
using DentalClinic.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.DentalOffices.Commands.CreateDentalOffice
{
    public class CreateDentalOfficeCommandHandler : IRequestHandler<CreateDentalOfficeCommand, Guid>
    {
        private readonly IDentalOfficeRepository _dentalOfficeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDentalOfficeCommandHandler(IDentalOfficeRepository dentalOfficeRepository, IUnitOfWork unitOfWork)
        {
            _dentalOfficeRepository = dentalOfficeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateDentalOfficeCommand command)
        {      
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
