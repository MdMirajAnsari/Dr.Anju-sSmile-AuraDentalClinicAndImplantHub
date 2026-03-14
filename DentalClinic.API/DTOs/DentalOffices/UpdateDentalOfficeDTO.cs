using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.API.DTOs.DentalOffices
{
    public class UpdateDentalOfficeDTO
    {
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }
    }
}
