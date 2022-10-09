using LoanApplicationWCFService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerServiceController : ControllerBase
    {
        private readonly CustomerServiceClient customerclient;
        public IConfiguration Configuration { get; }
        public CustomerServiceController(IConfiguration configuration)
        {
            Configuration = configuration;
            var baseAddress = configuration["CustomerService:BasAddress"];
            customerclient = new CustomerServiceClient(baseAddress);

        }
        // GET: api/<CustomerServiceController>
        [HttpGet]
        public CustomerModel[] GetAllCustomers()
        {
            var allCustomers = customerclient.GetAllCustomers();
            return allCustomers;
        }

        // GET api/<CustomerServiceController>/5
        [HttpGet("{id}")]
        public CustomerModel GetCustomerById(Guid id)
        {
            var customer = customerclient.GetCustomerById(id);
            return customer;
        }

        // POST api/<CustomerServiceController>
        [HttpPost]
        public void AddCustomer(CustomerModel customer)
        {
            customerclient.AddCustomer(customer);
        }

        // PUT api/<CustomerServiceController>/5
        [HttpPut("{id}")]
        public void UpdateCustomer(CustomerModel customer, Guid id)
        {
            customerclient.UpdateCustomer(customer, id);
        }

        // DELETE api/<CustomerServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            customerclient.DeleteCustomer(id);
        }
    }
}
