using LoanApplicationWCFService.Models;
using LoanApplicationWebAPI.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerServiceController : ControllerBase
    {
        private readonly CustomerDataService customerDataService;
        public CustomerServiceController(IConfiguration configuration)
        {
           customerDataService = new CustomerDataService(configuration);

        }
        // GET: api/<CustomerServiceController>
        [HttpGet]
        public CustomerModel[] GetAllCustomers()
        {
            var allCustomers = customerDataService.GetAllCustomers();
            return allCustomers;
        }

        // GET api/<CustomerServiceController>/5
        [HttpGet("{id}")]
        public CustomerModel GetCustomerById(Guid id)
        {
            var customer = customerDataService.GetCustomerById(id);
            return customer;
        }

        // POST api/<CustomerServiceController>
        [HttpPost]
        public void AddCustomer(CustomerModel customer)
        {
            customerDataService.AddCustomer(customer);
        }

        // PUT api/<CustomerServiceController>/5
        [HttpPut("{id}")]
        public void UpdateCustomer(CustomerModel customer, Guid id)
        {
            customer.Id = id;
            customerDataService.UpdateCustomer(customer, id);
        }

        // DELETE api/<CustomerServiceController>/5
        [HttpDelete("{id}")]
        public void DeleteCustomer(Guid id)
        {
            customerDataService.DeleteCustomer(id);
        }

        [HttpGet]
        [Route("/CheckUserExistsOrNot/{emailId}")]
        public bool CheckUserExistsOrNot(string emailId)
        {
            var isExistedUser = false;
            var allCustomers = GetAllCustomers();
            if (allCustomers != null && allCustomers.Length != 0)
            {
                isExistedUser = allCustomers.Any(customer => customer.EmailAddress.Equals(emailId, StringComparison.CurrentCultureIgnoreCase));
            }
            return isExistedUser;
        }

        [HttpGet]
        [Route("/GetCustomerByEmailId/{emailId}")]
        public CustomerModel? GetCustomerByEmailId(string emailId)
        {
            CustomerModel? customer = null;
            var allCustomers = GetAllCustomers();
            if (allCustomers != null && allCustomers.Length != 0)
            {
                customer = allCustomers.FirstOrDefault(customer => customer.EmailAddress.Equals(emailId, StringComparison.CurrentCultureIgnoreCase));
            }
            return customer;
        }


        [HttpGet]
        [Route("/IsValidUser/{emailId}/{password}")]
        public bool IsValidUser(string emailId, string password)
        {
            var isValidUser = false;
            var allCustomers = GetAllCustomers();
            if (allCustomers != null && allCustomers.Length != 0)
            {
                isValidUser = allCustomers.Any(customer => customer.EmailAddress.Equals(emailId, StringComparison.CurrentCultureIgnoreCase) &&
                customer.Password.Equals(password));
            }
            return isValidUser;
        }
    }
}
