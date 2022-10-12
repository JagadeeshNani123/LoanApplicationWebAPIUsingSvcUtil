using LoanApplicationWCFService.Models;
using LoanApplicationWebAPI.Services;

namespace LoanApplicationWebAPI.Implementations
{
    public class LoanDataService: ILoanDataService
    {
        private readonly LoanServiceClient loanServiceClient;
        public LoanDataService(string baseAddress)
        {
            
            loanServiceClient = new LoanServiceClient(baseAddress);

        }

        public LoanModel[] GetAllLoans()
        {
            var allLoans = loanServiceClient.GetAllLoans();
            return allLoans;
        }

        public LoanModel GetLoanById(Guid id)
        {
            var loan = loanServiceClient.GetLoanById(id);
            return loan;
        }

        public void AddLoan(LoanModel loan)
        {
            loanServiceClient.AddLoan(loan);
        }


        public void UpdateLoan(LoanModel loan, Guid id)
        {
            loanServiceClient.UpdateLoan(loan, id);
        }

        public void DeleteLoan(Guid id)
        {
            loanServiceClient.DeleteLoan(id);
        }

        public bool IsInsertedLoan(LoanModel loan)
        {
            var isInserted = true;
            try
            {
                loanServiceClient.AddLoan(loan);
            }
            catch (Exception e)
            {
                isInserted = false;
            }
            return isInserted;
        }

        public bool IsUpdatedLoan(Guid id, LoanModel loan)
        {
            var isUpdated = true;
            try
            {
                loanServiceClient.UpdateLoan(loan, id);
            }
            catch (Exception e)
            {
                isUpdated = false;
            }
            return isUpdated;
        }

        public bool IsDeletedLoan(Guid id)
        {
            var isDeleted = true;
            try
            {
                loanServiceClient.DeleteLoan(id);
            }
            catch (Exception e)
            {
                isDeleted = false;
            }
            return isDeleted;
        }
    }
}
