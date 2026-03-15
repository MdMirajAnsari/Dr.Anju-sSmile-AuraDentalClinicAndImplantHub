using DentalClinic.Application.Contracts.Persistence;
using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Exceptions;
using DentalClinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.DentalOffices.Commands.DeleteDentalOffice
{
    public class DeleteDentalOfficeCommandHandler : IRequestHandler<DeleteDentalOfficeCommand>
    {
        private readonly IDentalOfficeRepository _dentalOfficeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDentalOfficeCommandHandler(IDentalOfficeRepository dentalOfficeRepository, IUnitOfWork unitOfWork)
        {
            _dentalOfficeRepository = dentalOfficeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteDentalOfficeCommand request)
        {
            var dentalOffice = await _dentalOfficeRepository.GetByIdAsync(request.Id);

            if (dentalOffice == null) 
            {
                throw new NotFoundException();
            }

            try
            {
                await _dentalOfficeRepository.DeleteAsync(request.Id);
                await _unitOfWork.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
