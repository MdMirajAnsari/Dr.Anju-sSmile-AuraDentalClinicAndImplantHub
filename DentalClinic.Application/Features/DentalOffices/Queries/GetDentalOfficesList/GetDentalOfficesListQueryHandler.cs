using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.DentalOffices.Queries.GetDentalOfficesList
{
    public class GetDentalOfficesListQueryHandler : IRequestHandler<GetDentalOfficesListQuery, List<DentalOfficesListDTO>>
    {
        private readonly IDentalOfficeRepository _officeRepository;

        public GetDentalOfficesListQueryHandler(IDentalOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        public async Task<List<DentalOfficesListDTO>> Handle(GetDentalOfficesListQuery request)
        {
            var dentalOffices = await _officeRepository.GetAllAsync();
            var dentalOfficesList = dentalOffices.Select(o => new DentalOfficesListDTO
            {
                Id = o.Id,
                Name = o.Name
            }).ToList();
            return dentalOfficesList;
        }
    }
}
