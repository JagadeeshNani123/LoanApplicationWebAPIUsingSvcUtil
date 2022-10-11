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
        private readonly IFixture _fixture;
        private readonly Mock<IBankDetailsDataService> _bankDetailsService;
        private readonly BankDetailsDataService serviceClass;
        private readonly string baseUrl = "http://localhost:53564/WCFServices/BankDetailsService/BankDetailsService.svc";
        public BankDataServiceTest()
        {
            _fixture = new Fixture();
            _bankDetailsService = new Mock<IBankDetailsDataService>();
            var config = new Mock<IConfiguration>();
            var mockConfigSection = new Mock<IConfigurationSection>();
            mockConfigSection.SetupGet(m => m[It.Is<string>(s => s == "BaseAddress")]).Returns(baseUrl);
            config.Setup(s => s.GetSection(It.Is<string>(s => s == "BankService:BaseAddress"))).Returns(mockConfigSection.Object);
            serviceClass = new BankDetailsDataService(baseUrl);
        }

        [Fact]
        public void GetAllBanks()
        {

            //Arrange
            var fackBanksArray = _fixture.Create<BankDetailsModel[]>();
            _bankDetailsService.Setup(service => service.GetAllBankDetails()).Returns(fackBanksArray);

            //Act
            var result = serviceClass.GetAllBankDetails();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<BankDetailsModel[]>();

        }

        [Fact]
        public void InsertBankDetalis()
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
            _bankDetailsService.Setup(service => service.AddBankDetails(bankdetails));

            //Act
            var result = serviceClass.IsInsertedBankDetails(bankdetails);

            //Assert
            result.Should().BeTrue();

        }
    }
}
