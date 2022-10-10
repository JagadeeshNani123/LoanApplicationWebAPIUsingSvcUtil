using LoanApplicationWCFService.Models;
using LoanApplicationWebAPI.Services;

namespace LoanApplicationWebAPI.Implementations
{
    public class BankDetailsDataService: IBankDetailsDataService
    {
        private readonly BankDetailsServiceClient bankDetailsServiceClient;
        public IConfiguration Configuration { get; }
        public BankDetailsDataService(IConfiguration configuration)
        {
            Configuration = configuration;
            var baseAddress = configuration["BankDetailsService:BasAddress"];
            bankDetailsServiceClient = new BankDetailsServiceClient(baseAddress);

        }
        public BankDetailsModel[] GetAllBankDetails()
        {
            var allBankDetails = bankDetailsServiceClient.GetAllBankDetails();
            return allBankDetails;
        }
        public BankDetailsModel GetBankDetailsById(Guid id)
        {
            return bankDetailsServiceClient.GetBankDetailsById(id);
        }
        public void AddBankDetails(BankDetailsModel bankDetails)
        {
            bankDetailsServiceClient.AddBankDetails(bankDetails);
        }
        public void UpdateBankDetails(BankDetailsModel bankDetails, Guid id)
        {
            bankDetailsServiceClient.UpdateBankDetails(bankDetails, id);
        }
        public void DeleteBankDetails(Guid id)
        {
            bankDetailsServiceClient.DeleteBankDetails(id);
        }

    }
}
