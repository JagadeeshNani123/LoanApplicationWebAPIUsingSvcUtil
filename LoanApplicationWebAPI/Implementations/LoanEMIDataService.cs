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

        public bool IsDeletedLoanEMI(Guid id)
        {
            var isDeleted = true;
            try
            {
                loanEMIServiceClient.DeleteLoanEMI(id);
            }
            catch (Exception e)
            {
                isDeleted = false;
            }
            return isDeleted;
        }

        public bool IsInsertedLoanEMI(LoanEMIModel loanEMI)
        {
            var isInserted = true;
            try
            {
                loanEMIServiceClient.AddLoanEMI(loanEMI);
            }
            catch (Exception e)
            {
                isInserted = false;
            }
            return isInserted;
        }

        public bool IsUpdatedLoanEMI(Guid id, LoanEMIModel loanEMI)
        {
            var isUpdated = true;
            try
            {
                loanEMIServiceClient.UpdateLoanEMI(loanEMI, id);
            }
            catch (Exception e)
            {
                isUpdated = false;
            }
            return isUpdated;
        }

        public void UpdateLoanEMI(LoanEMIModel loanEMI, Guid id)
        {
            loanEMIServiceClient.UpdateLoanEMI(loanEMI, id);
        }
    }
}
