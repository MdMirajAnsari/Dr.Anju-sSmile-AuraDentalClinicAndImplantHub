using DentalClinic.Application.Utilities;
using FluentValidation;
using Microsoft.Testing.Platform.Requests;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Tests.Application.Utilities.Mediator
{
    [TestClass]
    public class SimpleMediatorTests
    {
        public class FalseRequest : IRequest<string>
        {
            public required string Name { get; set; }
        }

        public class FalseRequestHandler : AbstractValidator<FalseRequest>
        {
            public FalseRequestHandler()
            {
                RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("The Name field is required.")
                    .MaximumLength(100).WithMessage("The Name field must not exceed 100 characters.");
            }

        }

        [TestMethod]
        public async Task Send_ShouldThrowMediatorException_WhenNoHandlerIsFound()
        {
            var request = new FalseRequest() { Name = "Test" };
            var handlerMock = Substitute.For<IRequestHandler<FalseRequest, string>>();

            var serviceProvider = Substitute.For<IServiceProvider>();

            serviceProvider.GetService(typeof(IRequestHandler<FalseRequest, string>)).Returns(handlerMock);

            var mediator = new SimpleMediator(serviceProvider);

            var result = await mediator.Send(request);

            await handlerMock.Received(1).Handle(request);

        }

        [TestMethod]
        public async Task Send_ShouldThrowMediatorException_WhenHandlerIsNotFound()
        {
            var request = new FalseRequest()
            {
                Name = "Test"
            };
            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService(typeof(IRequestHandler<FalseRequest, string>)).Returns(null);
            var mediator = new SimpleMediator(serviceProvider);

            var result = await mediator.Send(request);

        }

        [TestMethod]
        public async Task Send_ShouldThrowCustomValidationException_WhenValidationFails()
        {
            var request = new FalseRequest() { Name = "" };
            var handlerMock = Substitute.For<IRequestHandler<FalseRequest, string>>();
            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService(typeof(IValidator<FalseRequest>)).Returns(new FalseRequestHandler());
            serviceProvider.GetService(typeof(IRequestHandler<FalseRequest, string>)).Returns(handlerMock);
            var mediator = new SimpleMediator(serviceProvider);
            var result = await mediator.Send(request);
            await handlerMock.DidNotReceive().Handle(request);
        }
    }
}
