using LoanApplicationWCFService.Models;
using LoanApplicationWebAPI.Services;

namespace LoanApplicationWebAPI.Implementations
{
    public class BankDetailsDataService: IBankDetailsDataService
    {
        private readonly BankDetailsServiceClient bankDetailsServiceClient;
        public BankDetailsDataService(string baseAddress)
        {
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
        public bool IsInsertedBankDetails(BankDetailsModel bankDetails)
        {
            var isInserted = true;
            try
            {
                bankDetailsServiceClient.AddBankDetails(bankDetails);
            }
            catch (Exception e)
            {
                isInserted = false;
            }
            return isInserted;
        }

       

        public bool IsUpdatedBankDetails(Guid id, BankDetailsModel bankDetails)
        {
            var isInserted = true;
            try
            {
                bankDetailsServiceClient.UpdateBankDetails(bankDetails,id);
            }
            catch (Exception e)
            {
                isInserted = false;
            }
            return isInserted;
        }

        public bool IsDeletedBankDetails(Guid id)
        {
            var isInserted = true;
            try
            {
                bankDetailsServiceClient.DeleteBankDetails(id);
            }
            catch (Exception e)
            {
                isInserted = false;
            }
            return isInserted;
        }
    }
}
