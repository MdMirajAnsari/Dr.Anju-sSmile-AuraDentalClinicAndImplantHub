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
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(builder => builder.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.ComplexProperty(builder => builder.Email, action =>
            {
                action.Property(e => e.Value).HasColumnName("Email").HasMaxLength(255).IsRequired();
            });
        }
    }
}
