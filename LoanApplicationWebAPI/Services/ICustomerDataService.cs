using LoanApplicationWCFService.Models;

namespace LoanApplicationWebAPI.Services
{
    public interface ICustomerDataService
    {
        public CustomerModel[] GetAllCustomers();
        public CustomerModel GetCustomerById(Guid id);
        public void AddCustomer(CustomerModel customer);
        public void UpdateCustomer(CustomerModel customer, Guid id);
        public void DeleteCustomer(Guid id);
    }
}
