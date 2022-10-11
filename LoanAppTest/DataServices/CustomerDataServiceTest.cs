using AutoFixture;
using FluentAssertions;
using LoanApplicationWCFService.Models;
using LoanApplicationWebAPI.Controllers;
using LoanApplicationWebAPI.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAppTest.DataServices
{
   
    public class CustomerDataServiceTest
    {
        private readonly IFixture _fixture;
        private readonly Mock<ICustomerDataService> _customerService;
        private readonly Mock<IConfiguration> config;
        private readonly CustomerServiceController serviceController;
        public CustomerDataServiceTest()
        {
            _fixture = new Fixture();
            _customerService = _fixture.Freeze<Mock<ICustomerDataService>>();
            config = _fixture.Freeze<Mock<IConfiguration>>();
            serviceController = new CustomerServiceController(config.Object); 
        }

        [Fact]
        public void InsertCustomer()
        {

            //Arrange
            var fackCustomersArray = _fixture.Create<CustomerModel[]>();
            _customerService.Setup(service=> service.GetAllCustomers()).Returns(fackCustomersArray);

            //Act
            var result = serviceController.GetAllCustomers();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<CustomerModel[]>();

        }
    }
}
