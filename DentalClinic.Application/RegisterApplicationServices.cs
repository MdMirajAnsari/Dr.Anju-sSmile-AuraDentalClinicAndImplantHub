using DentalClinic.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using DentalClinic.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using DentalClinic.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using DentalClinic.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using DentalClinic.Application.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application
{
    public static class RegisterApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IMediator, SimpleMediator>();
            services.AddScoped<IRequestHandler<CreateDentalOfficeCommand, Guid>, CreateDentalOfficeCommandHandler>();
            services.AddScoped<IRequestHandler<GetDentalOfficeDetailQuery, DentalOfficeDetailDTO>, GetDentalOfficeDetailQueryHandler>();
            services.AddScoped<IRequestHandler<GetDentalOfficesListQuery, List<DentalOfficesListDTO>>, GetDentalOfficesListQueryHandler>();
            services.AddScoped<IRequestHandler<UpdateDentalOfficeCommand>, UpdateDentalOfficeCommandHandler>();
            return services;
        }

    }
}
