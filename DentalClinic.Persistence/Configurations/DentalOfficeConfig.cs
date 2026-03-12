using DentalClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Persistence.Configurations
{
    public class DentalOfficeConfig : IEntityTypeConfiguration<DentalOffice>
    {
        public void Configure(EntityTypeBuilder<DentalOffice> builder)
        {
            builder.Property(builder => builder.Name)
                .HasMaxLength(100)
                .IsRequired();
           
        }

    }
}
