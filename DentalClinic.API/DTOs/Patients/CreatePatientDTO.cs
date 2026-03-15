using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.API.DTOs.Patients
{
    public class CreatePatientDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public required string Name { get; set; }

        [Required]
        [StringLength(255)]
        public required string Email { get; set; }  
    }
}
