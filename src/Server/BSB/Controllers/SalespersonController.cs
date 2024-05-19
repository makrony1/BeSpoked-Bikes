using BSB.BL.Services;
using BSB.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalespersonController : ControllerBase
    {
        private ISalespersonService _salespersonService;
        public SalespersonController(ISalespersonService salespersonService)
        {
            this._salespersonService = salespersonService;
        }
        // GET: api/<SalespersonController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await this._salespersonService.GetSalesPeopleAsync();
            if (response.success)
            {
                return this.Ok(response.salesperson);
            }
            else
            {
                return this.BadRequest(response.errorMessage);
            }
        }

        // GET api/<SalespersonController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            var response = await this._salespersonService.GetSalespersonByIdAsync(id);
            if (response.success)
            {
                return this.Ok(response.salseperson);
            }
            else
            {
                return this.BadRequest(response.errorMessage);
            }
        }

        // POST api/<SalespersonController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Salesperson person)
        {
            ArgumentNullException.ThrowIfNull(nameof(person));

            ValidationContext validationContext = new ValidationContext(person);
            var validationResult = new List<ValidationResult>();
            if (!Validator.TryValidateObject(person, validationContext, validationResult, true))
            {
                return this.BadRequest(string.Join(Environment.NewLine, validationResult.Select(vr => vr.ErrorMessage)));
            }

            var response = await this._salespersonService.CreateSalespersonAsync(person);
            if (response.success)
            {
                return this.Created($"/salesperson/{response.salseperson.Id}", response.salseperson);
            }
            else
            {
                return this.BadRequest(response.errorMessage);
            }
            return Ok();
        }

        // PUT api/<SalespersonController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putasync(string id, [FromBody] Salesperson person)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            ArgumentNullException.ThrowIfNull(nameof(person));

            ValidationContext validationContext = new ValidationContext(person);
            var validationResult = new List<ValidationResult>();
            if (!Validator.TryValidateObject(person, validationContext, validationResult, true))
            {
                return this.BadRequest(string.Join(Environment.NewLine, validationResult.Select(vr=>vr.ErrorMessage)));
            }

            var response = await this._salespersonService.UpdateSalespersonAsync(id, person);
            if (response.success)
            {
                return this.NoContent();
            }
            else
            {
                return this.BadRequest(response.errorMessage);
            }
        }

    }
}
