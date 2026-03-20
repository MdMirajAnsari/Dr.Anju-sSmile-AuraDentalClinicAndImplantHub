using DentalClinic.Security.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Security
{
    public class DentalClinicSecurityDbContext : IdentityDbContext<User>
    {
        public DentalClinicSecurityDbContext(DbContextOptions<DentalClinicSecurityDbContext> options) : base(options)
        {

        }
        protected DentalClinicSecurityDbContext()
        {

        }
    }
}
