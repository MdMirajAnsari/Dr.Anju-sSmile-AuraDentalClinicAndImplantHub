using DentalClinic.Application.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Utilities
{
    public class SimpleMediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public SimpleMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> response)
        {
            var validatorType = typeof(IValidator<>).MakeGenericType(response.GetType());

            var validator = _serviceProvider.GetService(validatorType);

            if (validator is not null)
            {
                var validatorMethod = validatorType.GetMethod("ValidatorAsync");
                var taskToValidate = (Task)validatorMethod!.Invoke(validator, new object[] { response, CancellationToken.None });

                await taskToValidate;

                var resultProperty = taskToValidate.GetType().GetProperty("Result");
                var validationResult = (ValidationResult)resultProperty!.GetValue(taskToValidate)!;

                if (!validationResult.IsValid)
                {
                    throw new CustomValidationException(validationResult);
                }
            }


            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(response.GetType(), typeof(TResponse));

            var hadler = _serviceProvider.GetService(handlerType);

            if (hadler == null)
            {
                throw new MediatorException($"No handler found for request of type {response.GetType()}");
            }

            var method = handlerType.GetMethod("Handle");
            return await (Task<TResponse>)method.Invoke(hadler, new object[] { response });
        }
    }
}
