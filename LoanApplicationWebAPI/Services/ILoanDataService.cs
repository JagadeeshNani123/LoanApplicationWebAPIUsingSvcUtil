using LoanApplicationWCFService.Models;

namespace LoanApplicationWebAPI.Services
{
    public interface ILoanDataService
    {
        public LoanModel[] GetAllLoans();
        public LoanModel GetLoanById(Guid id);
        public void AddLoan(LoanModel loan);
        public void UpdateLoan(LoanModel loan, Guid id);
        public void DeleteLoan(Guid id);

        public bool IsInsertedLoan(LoanModel loan);

        public bool IsUpdatedLoan(Guid id, LoanModel loan);
        public bool IsDeletedLoan(Guid id);
    }
}
