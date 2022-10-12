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
    public class LoanEMIDataServiceTest
    {
        private readonly Mock<ILoanEMIDataService> _loanEMIDetailsService;
        public LoanEMIDataServiceTest()
        {
            _loanEMIDetailsService = new Mock<ILoanEMIDataService>();
        }

        [Fact]
        public void GetLoanEMIDetailsById()
        {

            //Arrange

            _loanEMIDetailsService.Setup(bs => bs.GetLoanEMIById(It.IsAny<Guid>())).Returns(new LoanEMIModel());

            //Act
            var result = _loanEMIDetailsService.Object.GetLoanEMIById(Guid.NewGuid());

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<LoanEMIModel>();

        }

        [Fact]
        public void GetAllLoanEMIS()
        {

            //Arrange
            _loanEMIDetailsService.Setup(bs => bs.GetAllLoanEMIs()).Returns(new LoanEMIModel[1]);

            //Act
            var result = _loanEMIDetailsService.Object.GetAllLoanEMIs();

            //Assert
            result.Should().BeAssignableTo<LoanEMIModel[]>();

        }

        [Fact]
        public void InsertLoanEMI()
        {

            //Arrange

            _loanEMIDetailsService.Setup(bs => bs.IsInsertedLoanEMI(It.IsAny<LoanEMIModel>())).Returns(true);

            //Act
            var result = _loanEMIDetailsService.Object.IsInsertedLoanEMI(new LoanEMIModel());

            //Assert
            result.Should().BeTrue();

        }


        [Fact]
        public void DeleteLoanEMI()
        {

            //Arrange


            _loanEMIDetailsService.Setup(bs => bs.IsDeletedLoanEMI(It.IsAny<Guid>())).Returns(true);


            //Act
            var result = _loanEMIDetailsService.Object.IsDeletedLoanEMI(Guid.NewGuid());

            //Assert
            result.Should().BeTrue();

        }
    }
}

