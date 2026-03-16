using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DentalClinic.API.Utilities
{
    public static class HttpContextExtensions
    {
        private const string PaginationHeader = "X-Pagination";

        public static void InsertPaginationInformationInHeader(this HttpContext context, int totalAmountOfRecords)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var pagination = new { TotalAmountOfRecords = totalAmountOfRecords };
            var json = JsonSerializer.Serialize(pagination);

            context.Response.Headers[PaginationHeader] = json;

            // Ensure client can read the custom header in browsers
            if (!context.Response.Headers.ContainsKey("Access-Control-Expose-Headers"))
            {
                context.Response.Headers.Add("Access-Control-Expose-Headers", PaginationHeader);
            }
        }
    }
}
