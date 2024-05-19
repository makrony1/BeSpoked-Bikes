namespace BSB.BL.Services;

public interface IProductService
{
    Task<(Models.Models.Product product, bool success, string errorMessage)> CreateProductAsync(Models.Models.Product product);
    Task<(Models.Models.Product product, bool success, string errorMessage)> UpdateProductAsync(string id, Models.Models.Product product);
    Task<(Models.Models.Product product, bool success, string errorMessage)> GetProductByIdAsync(string Id);
    Task<(IEnumerable<Models.Models.Product> products, bool success, string errorMessage)> GetProductsAsync();
}
