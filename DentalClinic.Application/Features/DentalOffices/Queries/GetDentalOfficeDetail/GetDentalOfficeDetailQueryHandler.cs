using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Exceptions;
using DentalClinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail
{
    public class GetDentalOfficeDetailQueryHandler : IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDTO>
    {
        private readonly IDentalOfficeRepository _dentalOfficeRepository;

        public GetDentalOfficeDetailQueryHandler(IDentalOfficeRepository dentalOfficeRepository)
        {
            _dentalOfficeRepository = dentalOfficeRepository;
        }

        public async Task<DentalOfficeDetailDTO> Handle(GetDentalOfficeDetailQuery request)
        {
            var dentalOffice = await _dentalOfficeRepository.GetByIdAsync(request.Id);

            if (dentalOffice is null)
            {
                throw new NotFoundException();
            }

           return dentalOffice.ToDTO();
        }
    }
}
