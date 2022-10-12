using LoanApplicationWCFService.Models;

namespace LoanApplicationWebAPI.Services
{
    public interface ILoanEMIDataService
    {
        public LoanEMIModel[] GetAllLoanEMIs();
        public LoanEMIModel GetLoanEMIById(Guid id);
        public void AddLoanEMI(LoanEMIModel loanEMI);
        public void UpdateLoanEMI(LoanEMIModel loanEMI, Guid id);
        public void DeleteLoanEMI(Guid id);

        public bool IsInsertedLoanEMI(LoanEMIModel loanEMI);

        public bool IsUpdatedLoanEMI(Guid id, LoanEMIModel loanEMI);
        public bool IsDeletedLoanEMI(Guid id);
    }
}
