using LoanApplicationWCFService.Models;
using LoanApplicationWebAPI.Services;

namespace LoanApplicationWebAPI.Implementations
{
    public class LoanEMIDataService : ILoanEMIDataService
    {
        private readonly LoanEMIServiceClient loanEMIServiceClient;
        public LoanEMIDataService(string baseAddress)
        {
            loanEMIServiceClient = new LoanEMIServiceClient(baseAddress);
        }
        public void AddLoanEMI(LoanEMIModel loanEMI)
        {
            loanEMIServiceClient.AddLoanEMI(loanEMI);
        }

        public void DeleteLoanEMI(Guid id)
        {
           loanEMIServiceClient.DeleteLoanEMI(id);
        }

        public LoanEMIModel[] GetAllLoanEMIs()
        {
            var allLoanEMIs = loanEMIServiceClient.GetAllLoanEMIs();
            return allLoanEMIs;
        }

        public LoanEMIModel GetLoanEMIById(Guid id)
        {
            return loanEMIServiceClient.GetLoanEMIById(id);
        }

        public void UpdateLoanEMI(LoanEMIModel loanEMI, Guid id)
        {
            loanEMIServiceClient.UpdateLoanEMI(loanEMI, id);
        }
    }
}
