using DentalClinic.Security.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Security
{
    public static class RegisterSecurityServices
    {
        public static void AddSecurityServices(this IServiceCollection services)
        {
            services.AddAuthentication(IdentityConstants.BearerScheme).AddBearerToken(IdentityConstants.BearerScheme);

            services.AddAuthorization();

            services.AddDbContext<DentalClinicSecurityDbContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DentalClinicDb;Integrated Security=True;TrustServerCertificate=True");
            });

            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<DentalClinicSecurityDbContext>()
                .AddApiEndpoints();
        }

    }
}
