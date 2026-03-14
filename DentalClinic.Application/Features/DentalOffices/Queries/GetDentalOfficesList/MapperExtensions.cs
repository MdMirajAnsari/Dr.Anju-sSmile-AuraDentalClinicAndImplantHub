using DentalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.DentalOffices.Queries.GetDentalOfficesList
{
    public static class MapperExtensions
    {
        public static DentalOfficesListDTO ToDentalOfficesListDTO(this DentalOffice dentalOffice)
        {
            return new DentalOfficesListDTO
            {
                Id = dentalOffice.Id,
                Name = dentalOffice.Name
            };
        }

    }
}
