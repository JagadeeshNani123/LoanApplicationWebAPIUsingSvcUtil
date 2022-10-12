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
        private readonly Mock<ILoanDataService> _loanDataService;
        public LoanDataServiceTestcs()
        {
            _loanDataService = new Mock<ILoanDataService>();
        }

        [Fact]
        public void GetLoanDetailsById()
        {

            //Arrange

            _loanDataService.Setup(bs => bs.GetLoanById(It.IsAny<Guid>())).Returns(new LoanModel());

            //Act
            var result = _loanDataService.Object.GetLoanById(Guid.NewGuid());

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<LoanModel>();

        }

        [Fact]
        public void GetAllLoans()
        {

            //Arrange


            _loanDataService.Setup(bs => bs.GetAllLoans()).Returns(new LoanModel[1]);

            //Act
            var result = _loanDataService.Object.GetAllLoans();

            //Assert
            result.Should().BeAssignableTo<LoanModel[]>();

        }

        [Fact]
        public void InsertLoan()
        {

            //Arrange



            _loanDataService.Setup(bs => bs.IsInsertedLoan(It.IsAny<LoanModel>())).Returns(true);

            //Act
            var result = _loanDataService.Object.IsInsertedLoan(new LoanModel());

            //Assert
            result.Should().BeTrue();

        }


        [Fact]
        public void DeleteLoanDetails()
        {

            //Arrange


            _loanDataService.Setup(bs => bs.IsDeletedLoan(It.IsAny<Guid>())).Returns(true);


            //Act
            var result = _loanDataService.Object.IsDeletedLoan(Guid.NewGuid());

            //Assert
            result.Should().BeTrue();

        }


    }
}

