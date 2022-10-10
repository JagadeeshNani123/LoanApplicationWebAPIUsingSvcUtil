using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoanApplicationWebAPI.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanApplicationWCFService.Models;
using NPOI.SS.Formula.Functions;
using Xunit;

namespace DataServices.Tests
{
    [TestClass]
    public class CustomerDataServiceTests
    {
        public CustomerDataServiceTests()
        {

        }

        [Fact]
        public void AddCustomerTest(CustomerModel customer)
        {
            Assert.Fail();
        }
    }
}