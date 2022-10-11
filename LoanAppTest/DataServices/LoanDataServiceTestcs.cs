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
    public class LoanDataServiceTestcs
    {
        private readonly IFixture _fixture;
        private readonly Mock<ILoanDataService> _loanService;
        private readonly LoanDataService serviceClass;
        string baseUrl = "http://localhost:53564/WCFServices/LoanService/LoanService.svc";
        public LoanDataServiceTestcs()
        {
            _fixture = new Fixture();
            _loanService = new Mock<ILoanDataService>();
            var config = new Mock<IConfiguration>();
            var mockConfigSection = new Mock<IConfigurationSection>();
            mockConfigSection.SetupGet(m => m[It.Is<string>(s => s == "BasAddress")]).Returns(baseUrl);
            config.Setup(s => s.GetSection(It.Is<string>(s => s == "LoanService:BasAddress"))).Returns(mockConfigSection.Object);
            serviceClass = new LoanDataService(baseUrl);
        }

        [Fact]
        public void GetAllLoans()
        {

            //Arrange
            var fackLoansArray = _fixture.Create<LoanModel[]>();
            _loanService.Setup(service => service.GetAllLoans()).Returns(fackLoansArray);

            //Act
            var result = serviceClass.GetAllLoans();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<LoanModel[]>();

        }

        [Fact]
        public void InsertLoan()
        {

            //Arrange

            Random random = new Random();


            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string emailId = new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            var loan = new LoanModel
            {
                LoanId = Guid.NewGuid(),
                CustomerId = new Guid("11F4CB09-E9C4-42F6-A65A-4D072463614D"),
                IsActive = true,
                LoanAmount = 10000,
                LoanApprovedDate ="12-09-2022",
                LoanTenure=3,
                LoanType ="s-t"
            };
            _loanService.Setup(service => service.AddLoan(loan));

            //Act
            var result = serviceClass.IsInsertedLoan(loan);

            //Assert
            result.Should().BeTrue();

        }
    }
}
