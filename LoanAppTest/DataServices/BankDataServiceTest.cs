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
    public class BankDataServiceTest
    {
        private readonly Mock<IBankDetailsDataService> _bankDetailsService;
        public BankDataServiceTest()
        {
            _bankDetailsService = new Mock<IBankDetailsDataService>();
        }

        [Fact]
        public void GetBankDetailsById()
        {

            //Arrange
           
            _bankDetailsService.Setup(bs => bs.GetBankDetailsById(It.IsAny<Guid>())).Returns(new BankDetailsModel());

            //Act
            var result = _bankDetailsService.Object.GetBankDetailsById(Guid.NewGuid());

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BankDetailsModel>();

        }

        [Fact]
        public void GetAllBankDetails()
        {

            //Arrange

            var bankdetails = new BankDetailsModel
            {
                BankId = Guid.NewGuid(),
                BankAccountNumber="1234567890",
                BankName ="SBI",
                CustomerId = new Guid("11F4CB09-E9C4-42F6-A65A-4D072463614D"),
                IFSCCode ="SBI0890"

            };

            _bankDetailsService.Setup(bs => bs.GetAllBankDetails()).Returns(new BankDetailsModel[1]);

            //Act
            var result = _bankDetailsService.Object.GetAllBankDetails();

            //Assert
            result.Should().BeAssignableTo<BankDetailsModel[]>();

        }

        [Fact]
        public void InsertBankDetails()
        {

            //Arrange

            var bankdetails = new BankDetailsModel
            {
                BankId = Guid.NewGuid(),
                BankAccountNumber = "1234567890",
                BankName = "SBI",
                CustomerId = new Guid("11F4CB09-E9C4-42F6-A65A-4D072463614D"),
                IFSCCode = "SBI0890"

            };

            _bankDetailsService.Setup(bs => bs.IsInsertedBankDetails(It.IsAny<BankDetailsModel>())).Returns(true);

            //Act
            var result = _bankDetailsService.Object.IsInsertedBankDetails(bankdetails);

            //Assert
            result.Should().BeTrue();

        }


        [Fact]
        public void DeleteBankdetails()
        {

            //Arrange

            var bankdetails = new BankDetailsModel
            {
                BankId = Guid.NewGuid(),
                BankAccountNumber = "1234567890",
                BankName = "SBI",
                CustomerId = new Guid("11F4CB09-E9C4-42F6-A65A-4D072463614D"),
                IFSCCode = "SBI0890"

            };
            _bankDetailsService.Setup(bs => bs.IsDeletedBankDetails(It.IsAny<Guid>())).Returns(true);


            //Act
            var result = _bankDetailsService.Object.IsDeletedBankDetails(bankdetails.CustomerId);

            //Assert
            result.Should().BeTrue();

        }

       
    }
}
