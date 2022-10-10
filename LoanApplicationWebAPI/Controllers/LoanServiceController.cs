using LoanApplicationWCFService.Models;
using LoanApplicationWebAPI.Implementations;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Util;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanServiceController : ControllerBase
    {
        private readonly LoanDataService loanDataService;
        public LoanServiceController(IConfiguration configuration)
        {
            loanDataService = new LoanDataService(configuration);

        }
        // GET: api/<loanServiceController>
        [HttpGet]
        public LoanModel[] GetAllLoans()
        {
            var allLoans = loanDataService.GetAllLoans();
            return allLoans;
        }

        // GET api/<loanServiceController>/5
        [HttpGet("{id}")]
        public LoanModel GetLoanById(Guid id)
        {
            var loan = loanDataService.GetLoanById(id);
            return loan;
        }

        // POST api/<loanServiceController>
        [HttpPost]
        public void AddLoan(LoanModel loan)
        {
            loanDataService.AddLoan(loan);
        }

        // PUT api/<loanServiceController>/5
        [HttpPut("{id}")]
        public void UpdateLoan(LoanModel loan, Guid id)
        {
            loan.LoanId = id;
            loanDataService.UpdateLoan(loan, id);
        }

        // DELETE api/<loanServiceController>/5
        [HttpDelete("{id}")]
        public void DeleteLoan(Guid id)
        {
            loanDataService.DeleteLoan(id);
        }

        [HttpGet]
        [Route("GetAllLoansByCustomerId")]
        public async Task<List<LoanModel>?> GetAllLoansByCustomerId(string id)
        {
            var allLoans = GetAllLoans();
            List<LoanModel>? customerLoans = null;
            if (allLoans != null && allLoans.Length != 0)
            {
                var customerId = new Guid(id);
                customerLoans = allLoans.Where(all => all.CustomerId == customerId).ToList();
            }
            return customerLoans;
        }

        [HttpGet]
        [Route("GetFormattedDate")]
        public DateTime GetFormattedDate(string dateText)
        {
            var date = Convert.ToDateTime(dateText).Date;
            return date;
        }

        [HttpGet]
        [Route("GetOverAllLoanAmountOnExistingLoans")]
        public decimal GetOverAllLoanAmountOnExistingLoans(string id)
        {
            var allLons = GetAllLoans();
            var overAllLoanAmount = 0m;
            if (allLons != null && allLons.Length != 0)
            {
                overAllLoanAmount = allLons.Sum(all => all.LoanAmount);
            }
            return overAllLoanAmount;
        }
    }
}
