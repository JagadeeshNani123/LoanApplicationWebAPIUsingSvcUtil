using LoanApplicationWCFService.Models;
using LoanApplicationWebAPI.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankDetailsServiceController : ControllerBase
    {
        // GET: api/<BankDetailsServiceController>
        private readonly BankDetailsDataService bankDetailsDataService;
        public BankDetailsServiceController(IConfiguration configuration)
        {
            var baseAddress = configuration["BankDetailsService:BaseAddress"];
            bankDetailsDataService = new BankDetailsDataService(baseAddress);

        }
        // GET: api/<loanServiceController>
        [HttpGet]
        public BankDetailsModel[] GetBankDetails()
        {
            var allBankDetails = bankDetailsDataService.GetAllBankDetails();
            return allBankDetails;
        }

        // GET api/<loanServiceController>/5
        [HttpGet("{id}")]
        public BankDetailsModel GetBankDetailsById(Guid id)
        {
            var bankDetails = bankDetailsDataService.GetBankDetailsById(id);
            return bankDetails;
        }

        // POST api/<loanServiceController>
        [HttpPost]
        public void AddBankDetails([FromBody] BankDetailsModel banksDetails)
        {
            bankDetailsDataService.AddBankDetails(banksDetails);
        }

        // PUT api/<loanServiceController>/5
        [HttpPut("{id}")]
        public void UpdateBankDetails(BankDetailsModel bankDetails, Guid id)
        {
            bankDetails.BankId = id;
            bankDetailsDataService.UpdateBankDetails(bankDetails, id);
        }

        // DELETE api/<loanServiceController>/5
        [HttpDelete("{id}")]
        public void DeleteBankDetails(Guid id)
        {
            bankDetailsDataService.DeleteBankDetails(id);
        }

        [HttpGet]
        [Route("GetAllBankDetailsByCustomerId")]
        public BankDetailsModel[] GetAllBankDetailsByCustomerId(Guid id)
        {
            var bankDetails = GetBankDetails();
            var customerBankDetails =  bankDetails.Where(bank=> bank.CustomerId == id).ToArray();
            return customerBankDetails;
        }
    }
}
