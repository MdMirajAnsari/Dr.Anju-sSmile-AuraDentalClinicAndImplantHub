using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.API.DTOs.DentalOffices
{
    public class CreateDentalOfficeDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "The Name field must not exceed 100 characters.")]
        public required string Name { get; set; }

    }
}
