using BSB.BL.Services;
using BSB.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BSB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var productResponse = await this.productService.GetProductsAsync();
            if (productResponse.success)
            {
                return this.Ok(productResponse.products);
            }
            else
            {
                return this.BadRequest(productResponse.errorMessage);
            }
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var productResponse = await this.productService.GetProductByIdAsync(id);
            if (productResponse.success)
            {
                return this.Ok(productResponse.product);
            }
            else
            {
                return this.BadRequest(productResponse.errorMessage);
            }
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Postasync([FromBody] Product product)
        {
            ArgumentNullException.ThrowIfNull(nameof(product));

            ValidationContext validationContext = new ValidationContext(product);
            var validationResult = new List<ValidationResult>();
            if (!Validator.TryValidateObject(product, validationContext, validationResult, true))
            {
                return this.BadRequest(string.Join(Environment.NewLine, validationResult.Select(vr => vr.ErrorMessage)));
            }

            var productResponse = await this.productService.CreateProductAsync(product);
            if (productResponse.success)
            {
                return this.Ok(productResponse.product);
            }
            else
            {
                return this.BadRequest(productResponse.errorMessage);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] Product product)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }
            ArgumentNullException.ThrowIfNull(nameof(product));

            ValidationContext validationContext = new ValidationContext(product);
            var validationResult = new List<ValidationResult>();
            if(!Validator.TryValidateObject(product, validationContext, validationResult, true))
            {
                return this.BadRequest(string.Join(Environment.NewLine, validationResult.Select(vr => vr.ErrorMessage)));
            }

            var productResponse = await this.productService.UpdateProductAsync(id, product);
            if (productResponse.success)
            {
                return this.NoContent();
            }
            else
            {
                return this.BadRequest(productResponse.errorMessage);
            }
        }
    }
}
