using LoanApplicationWCFService.Models;
using LoanApplicationWebAPI.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanEMIServiceController : ControllerBase
    {
        private readonly LoanEMIDataService loanEMIDataService;
        public LoanEMIServiceController(IConfiguration configuration)
        {
            loanEMIDataService = new LoanEMIDataService(configuration);

        }
        // GET: api/<loanServiceController>
        [HttpGet]
        public LoanEMIModel[] GetAllLoansEmisById(Guid id)
        {
            var allLoanEMIs = loanEMIDataService.GetAllLoanEMIs();
            var customerEMIs = allLoanEMIs.Where(all => all.LoanId == id).ToArray();
            return customerEMIs;
        }

        // GET api/<loanServiceController>/5
        [HttpGet("{id}")]
        public LoanEMIModel GetLoanEMIById(Guid id)
        {
            var loanEMI = loanEMIDataService.GetLoanEMIById(id);
            return loanEMI;
        }

        // POST api/<loanServiceController>
        [HttpPost]
        public void AddLoanEMI([FromBody]LoanEMIModel loanEMI)
        {
            loanEMIDataService.AddLoanEMI(loanEMI);
        }

        // PUT api/<loanServiceController>/5
        [HttpPut("{id}")]
        public void UpdateLoanEMI(LoanEMIModel loanEMI, Guid id)
        {
            loanEMI.EMIId = id;
            loanEMIDataService.UpdateLoanEMI(loanEMI, id);
        }

        // DELETE api/<loanServiceController>/5
        [HttpDelete("{id}")]
        public void DeleteLoanEMI(Guid id)
        {
            loanEMIDataService.DeleteLoanEMI(id);
        }

        [HttpPost]
        [Route("AddEMI")]
        public void ModifyLoanAndAddLoanEMI(LoanModel loan)
        {
            var emiModel = new LoanEMIModel();
            emiModel.EMIId = Guid.NewGuid();
            emiModel.LoanId = loan.LoanId;
            emiModel.EMIAmout = loan.LoanAmount / loan.LoanTenure;
            emiModel.EMIPaymentDate = DateTime.Now.ToShortDateString();
            var loanEMIs = GetAllLoansEmisById(loan.LoanId);
            emiModel.EMINo = loanEMIs.Length+ 1;
            AddLoanEMI(emiModel);
        }
    }
}
