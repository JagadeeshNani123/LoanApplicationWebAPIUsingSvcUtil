using LoanApplicationWCFService.Models;
using LoanApplicationWebAPI.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            var baseAddress = configuration["LoanService:BaseAddress"];
            loanDataService = new LoanDataService(baseAddress);

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
        public void AddLoan([FromBody] LoanModel loan)
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
        [Route("IsValidUserToUserToApplyLoan")]
        public bool IsValidUserToUserToApplyLoan(string dateOfBirth)
        {
            var dob = Convert.ToDateTime(dateOfBirth).Date;
            int age = DateTime.Now.Subtract(dob).Days;
            age = age / 365;
            var validUserToUserToApplyLoan = age > 18;
            return validUserToUserToApplyLoan;
        }
    }
}
