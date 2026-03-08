using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Utilities
{
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> response); 
    }
}
