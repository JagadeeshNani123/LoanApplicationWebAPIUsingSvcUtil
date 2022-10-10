using LoanApplicationWCFService.Models;
using LoanApplicationWebAPI.Services;

namespace LoanApplicationWebAPI.Implementations
{
    public class LoanDataService: ILoanDataService
    {
        private readonly LoanServiceClient loanServiceClient;
        public IConfiguration Configuration { get; }
        public LoanDataService(IConfiguration configuration)
        {
            Configuration = configuration;
            var baseAddress = configuration["LoanService:BasAddress"];
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
    }
}
