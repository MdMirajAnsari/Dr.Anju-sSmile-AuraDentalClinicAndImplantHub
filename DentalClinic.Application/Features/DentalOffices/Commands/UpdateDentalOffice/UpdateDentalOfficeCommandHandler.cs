using DentalClinic.Application.Contracts.Persistence;
using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Exceptions;
using DentalClinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.DentalOffices.Commands.UpdateDentalOffice
{
    public class UpdateDentalOfficeCommandHandler : IRequestHandler<UpdateDentalOfficeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDentalOfficeRepository _entityRepository;

        public UpdateDentalOfficeCommandHandler(IUnitOfWork unitOfWork, IDentalOfficeRepository entityRepository)
        {
            _unitOfWork = unitOfWork;
            _entityRepository = entityRepository;
        }

        public async Task Handle(UpdateDentalOfficeCommand request)
        {
            var dentalOfficeToUpdate = await _entityRepository.GetByIdAsync(request.Id);

            if (dentalOfficeToUpdate == null) 
            {
                throw new NotFoundException();
            }

            dentalOfficeToUpdate.Update(request.Name);

            try
            {
                await _entityRepository.UpdateAsync(dentalOfficeToUpdate);
                await _unitOfWork.Commit();
            }
            catch (Exception ex) 
            {
                await _unitOfWork.Rollback();
                throw ex;
            }
        }
    }
}
