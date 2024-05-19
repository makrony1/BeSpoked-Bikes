using BSB.BL.Services;
using BSB.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private ISalesServcie salesServcie;
        public SalesController(ISalesServcie salesServcie)
        {
            this.salesServcie = salesServcie;
        }


        // GET: api/<SalesController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var sales = await this.salesServcie.GetSalesAsync();
            return this.Ok(sales);
        }

        // POST api/<SalesController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SalesCreate salesCreate)
        {
            
            ArgumentNullException.ThrowIfNull(nameof(salesCreate));

            ValidationContext validationContext = new ValidationContext(salesCreate);
            var validationResult = new List<ValidationResult>();
            if (!Validator.TryValidateObject(salesCreate, validationContext, validationResult, true))
            {
                return this.BadRequest(string.Join(Environment.NewLine, validationResult.Select(vr => vr.ErrorMessage)));
            }


            var response = await this.salesServcie.CreateSalesAsync(salesCreate);
            if (response.success)
            {
                return this.Created("/sales", response.sales);
            }
            else
            {
                return this.BadRequest(response.errorMessage);
            }
        }

    }
}
