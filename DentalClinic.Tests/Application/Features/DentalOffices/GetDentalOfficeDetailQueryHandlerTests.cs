using DentalClinic.Application.Contracts.Repositories;
using DentalClinic.Application.Exceptions;
using DentalClinic.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using DentalClinic.Domain.Entities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Tests.Application.Features.DentalOffices
{
    [TestClass]
    public class GetDentalOfficeDetailQueryHandlerTests
    {
        private IDentalOfficeRepository _dentalOfficeRepository;
        private GetDentalOfficeDetailQueryHandler _handler;

        [TestInitialize]
        public void Setup()
        {
            _dentalOfficeRepository = Substitute.For<IDentalOfficeRepository>();
            _handler = new GetDentalOfficeDetailQueryHandler(_dentalOfficeRepository);
        }

        [TestMethod]
        public async Task Handle_ShouldReturnDentalOfficeDetailDTO_WhenDentalOfficeExists()
        {

            var dentalOffice = new DentalOffice("Dental Office Name");
            var id = dentalOffice.Id;
            var query = new GetDentalOfficeDetailQuery { Id = id };

            _dentalOfficeRepository.GetByIdAsync(id).Returns(dentalOffice);
            // Act
            var result = await _handler.Handle(query);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual("Test Dental Office", result.Name);
        }

        //[TestMethod]
        //[Exception(typeof(NotFoundException))]
        //public async Task Handle_ShouldThrowNotFoundException_WhenDentalOfficeDoesNotExist()
        //{
        //    var id = Guid.NewGuid();
        //    var query = new GetDentalOfficeDetailQuery { Id = id };
        //    _dentalOfficeRepository.GetByIdAsync(id).Returns((DentalOffice)null);
        //    // Act
        //    await _handler.Handle(query);


        //}
    }
}
