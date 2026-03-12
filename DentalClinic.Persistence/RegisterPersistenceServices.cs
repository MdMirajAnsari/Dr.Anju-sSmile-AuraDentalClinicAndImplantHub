using DentalClinic.Application.Contracts.Persistence;
using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Persistence.Repositories;
using DentalClinic.Persistence.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Persistence
{
    public class RegisterPersistenceServices
    {
        public static IServiceCollection AddPersistenceServices(IServiceCollection services) 
        {
            services.AddDbContext<DentalClinicDbContext>(options =>
            {
                options.UseSqlServer("DentalClinicDbConnectionString");
            });

            services.AddScoped<IDentalOfficeRepository, DentalOfficeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWorkEFCore>();

            return services;
        }

    }
}
