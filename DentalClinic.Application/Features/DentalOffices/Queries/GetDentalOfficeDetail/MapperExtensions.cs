using DentalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail
{
    public static class MapperExtensions
    {
        public static DentalOfficeDetailDTO ToDTO(this DentalOffice dentalOffice)
        {
            return new DentalOfficeDetailDTO
            {
                Id = dentalOffice.Id,
                Name = dentalOffice.Name
            };
        }

    }
}
