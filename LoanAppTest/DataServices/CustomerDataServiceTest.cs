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
        private readonly Mock<ICustomerDataService> _customerDataService;
        public CustomerDataServiceTest()
        {
            _customerDataService = new Mock<ICustomerDataService>();
        }

        [Fact]
        public void GetCustmorDetailsById()
        {

            //Arrange

            _customerDataService.Setup(bs => bs.GetCustomerById(It.IsAny<Guid>())).Returns(new CustomerModel());

            //Act
            var result = _customerDataService.Object.GetCustomerById(Guid.NewGuid());

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<CustomerModel>();

        }

        [Fact]
        public void GetAllCustomers()
        {

            //Arrange

            

            _customerDataService.Setup(bs => bs.GetAllCustomers()).Returns(new CustomerModel[1]);

            //Act
            var result = _customerDataService.Object.GetAllCustomers();

            //Assert
            result.Should().BeAssignableTo<CustomerModel[]>();

        }

        [Fact]
        public void InsertCustomer()
        {

            //Arrange

           

            _customerDataService.Setup(bs => bs.IsInsertedCustomer(It.IsAny<CustomerModel>())).Returns(true);

            //Act
            var result = _customerDataService.Object.IsInsertedCustomer(new CustomerModel());

            //Assert
            result.Should().BeTrue();

        }


        [Fact]
        public void DeleteBankdetails()
        {

            //Arrange

           
            _customerDataService.Setup(bs => bs.IsDeletedCustomer(It.IsAny<Guid>())).Returns(true);


            //Act
            var result = _customerDataService.Object.IsDeletedCustomer(Guid.NewGuid());

            //Assert
            result.Should().BeTrue();

        }


    }
}
