using LoanApplicationWCFService.Models;
using LoanApplicationWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoanApplicationWebAPI.Implementations
{
    public class CustomerDataService: ICustomerDataService
    {
        private readonly CustomerServiceClient customerclient;
        public CustomerDataService(string baseAddress)
        {
            customerclient = new CustomerServiceClient(baseAddress);

        }

        public CustomerModel[] GetAllCustomers()
        {
            var allCustomers = customerclient.GetAllCustomers();
            return allCustomers;
        }

        public CustomerModel GetCustomerById(Guid id)
        {
            var customer = customerclient.GetCustomerById(id);
            return customer;
        }

        public void AddCustomer(CustomerModel customer)
        {
            customerclient.AddCustomer(customer);
        }

        
        public void UpdateCustomer(CustomerModel customer, Guid id)
        {
            customerclient.UpdateCustomer(customer, id);
        }

        public void DeleteCustomer(Guid id)
        {
            customerclient.DeleteCustomer(id);
        }

        public bool IsInsertedCustomer(CustomerModel customer)
        {
            var isInserted=true;
            try
            {
                customerclient.AddCustomer(customer);
            }
            catch(Exception e)
            {
                isInserted = false;
            }
            return isInserted;
        }

        public bool IsUpdatedCustomer(Guid id, CustomerModel customer)
        {
            var isUpdated = true;
            try
            {
                customerclient.UpdateCustomer(customer, id);
            }
            catch (Exception e)
            {
                isUpdated = false;
            }
            return isUpdated;
        }

        public bool IsDeletedCustomer(Guid id)
        {
            var isDeleted = true;
            try
            {
                customerclient.DeleteCustomer(id);
            }
            catch (Exception e)
            {
                isDeleted = false;
            }
            return isDeleted;
        }
    }
}
