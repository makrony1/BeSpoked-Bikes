using BSB.BL.Services;
using BSB.Models.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }


        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var customerResponse = await this.customerService.GetCustomersAsync();
            if (customerResponse.success)
            {
                return this.Ok(customerResponse.customers);
            }
            return this.BadRequest(customerResponse.errorMessage);
        }

        // GET api/<CustomerController>/5
        [HttpGet("api/[controller]/byname")]
        public async Task<IActionResult> GetAsync([FromQuery] string name)
        {
            var customerResponse = await this.customerService.GetCustomersByName(name);
            if (customerResponse.success)
            {
                return this.Ok(customerResponse.customers);
            }
            return this.BadRequest(customerResponse.errorMessage);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] Customer customer)
        {
            var customerResponse = await this.customerService.CreateCutomerAsync(customer);
            if (customerResponse.success)
            {
                return this.Created($"/customers/{customerResponse.customer.Id}", customerResponse.customer);
            }
            return this.BadRequest(customerResponse.errorMessage);
        }

    }
}
