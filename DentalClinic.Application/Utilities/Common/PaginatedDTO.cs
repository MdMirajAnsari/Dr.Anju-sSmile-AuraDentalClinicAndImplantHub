using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Utilities.Common
{
    public class PaginatedDTO<T>
    {
        public List<T> Elements { get; set; } = [];
        public int TotalAmountOfRecords { get; set; }

    }
}
