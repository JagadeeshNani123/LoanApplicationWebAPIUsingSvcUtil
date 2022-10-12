using LoanApplicationWCFService.Models;

namespace LoanApplicationWebAPI.Services
{
    public interface IBankDetailsDataService
    {
        public BankDetailsModel[] GetAllBankDetails();
        public BankDetailsModel GetBankDetailsById(Guid id);
        public void AddBankDetails(BankDetailsModel bankDetails);
        public void UpdateBankDetails(BankDetailsModel bankDetails, Guid id);
        public void DeleteBankDetails(Guid id);
        public bool IsInsertedBankDetails(BankDetailsModel bankDetails);

        public bool IsUpdatedBankDetails(Guid id, BankDetailsModel bankDetails);
        public bool IsDeletedBankDetails(Guid id);

    }
}
