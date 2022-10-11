using AutoFixture;
using FluentAssertions;
using LoanApplicationWCFService.Models;
using LoanApplicationWebAPI.Controllers;
using LoanApplicationWebAPI.Implementations;
using LoanApplicationWebAPI.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using NPOI.SS.Formula.Functions;
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
        private readonly CustomerDataService serviceClass;
        private readonly string baseUrl = "http://localhost:53564/WCFServices/CustomerService/CustomerService.svc";
        public CustomerDataServiceTest()
        {
            _fixture = new Fixture();
            _customerService = new Mock<ICustomerDataService>();
            var config = new Mock<IConfiguration>();
            var mockConfigSection = new Mock<IConfigurationSection>();
            mockConfigSection.SetupGet(m => m[It.Is<string>(s => s == "BasAddress")]).Returns(baseUrl);
            config.Setup(s=> s.GetSection(It.Is<string>(s => s == "CustomerService:BasAddress"))).Returns(mockConfigSection.Object);
            serviceClass = new CustomerDataService(baseUrl);
        }

        [Fact]
        public void GetAllCustomers()
        {

            //Arrange
            var fackCustomersArray = _fixture.Create<CustomerModel[]>();
            _customerService.Setup(service=> service.GetAllCustomers()).Returns(fackCustomersArray);

            //Act
            var result = serviceClass.GetAllCustomers();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<CustomerModel[]>();

        }

        [Fact]
        public void InsertCustomer()
        {

            //Arrange

         Random random = new Random();


        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string emailId = new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        var customer = new CustomerModel
            {
                Id = Guid.NewGuid(),
                FirstName = "Test1",
                LastName = "Test2",
                EmailAddress = emailId+"Test@mail.com",
                Password = "abcdefgh",
                Income = 70000,
                DateOfBirth = "21-01-1998",
                PanCardNumber = "1234567890",
                AddressProof = "adhar",
                AddressProofNumber = "1234567890",
                EmploymentType = "direct1234",
                MaritialStatus = "single",
                PhoneNumber = "1234567890"
            };
            _customerService.Setup(service => service.AddCustomer(customer));

            //Act
             var result = serviceClass.IsInsertedCustomer(customer);

            //Assert
            result.Should().BeTrue();

        }
    }
}
