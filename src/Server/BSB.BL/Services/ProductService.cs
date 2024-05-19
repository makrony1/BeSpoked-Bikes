using AutoMapper;
using BSB.DataAccess;
using BSB.Models.Models;

namespace BSB.BL.Services;

public class ProductService : IProductService
{
    private IRepositoryManager repositoryManager;
    private IMapper mapper;
    public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        this.repositoryManager = repositoryManager;
        this.mapper = mapper;
    }
    public async Task<(Product product, bool success, string errorMessage)> CreateProductAsync(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);
        var producttoinsert = this.mapper.Map<Models.Entity.Product>(product);
        producttoinsert.Id = Guid.NewGuid().ToString();
        var existingproduct = this.repositoryManager.ProductRepository.FindByCondition(
            p => p.Name.Equals(product.Name) &&
            p.Manufacturer.Equals(product.Manufacturer) &&
            p.Style.Equals(product.Style));
        if (existingproduct.Any(p => !p.IsDeleted))
        {
            return (null, false, "Product already exist.");
        }
        this.repositoryManager.ProductRepository.Create(producttoinsert);
        await this.repositoryManager.SaveChangesAsync();
        product.Id = producttoinsert.Id;
        return (product, true, string.Empty);
    }

    public async Task<(Product product, bool success, string errorMessage)> GetProductByIdAsync(string Id)
    {
        if (string.IsNullOrWhiteSpace(Id))
        {
            throw new ArgumentNullException(nameof(Id));
        }
        var productQuery = this.repositoryManager.ProductRepository.FindByCondition(
            p => p.Id.Equals(Id) && !p.IsDeleted);
        if (productQuery.Any())
        {
            var productToReturn = this.mapper.Map<Models.Models.Product>(productQuery.First());

            return (productToReturn, true, string.Empty);
        }
        return (product: null, success: false, errorMessage: string.Empty);
    }

    public Task<(IEnumerable<Product> products, bool success, string errorMessage)> GetProductsAsync()
    {
        var productQuery = this.repositoryManager.ProductRepository.FindByCondition(p => !p.IsDeleted);
        var productToReturn = this.mapper.Map<IEnumerable<Models.Models.Product>>(productQuery.ToList());
        return Task.FromResult((productToReturn, true, string.Empty));
    }

    public async Task<(Product product, bool success, string errorMessage)> UpdateProductAsync(string id, Product product)
    {
        ArgumentNullException.ThrowIfNull(product);
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentNullException(nameof(id));
        }
        var existingproduct = this.repositoryManager.ProductRepository.FindByCondition(
            p => p.Name.Equals(product.Name) &&
            p.Manufacturer.Equals(product.Manufacturer) &&
            p.Style.Equals(product.Style) &&
            !p.Id.Equals(id));
        if (existingproduct.Any(p => !p.IsDeleted))
        {
            return (null, false, "Product already exist.");
        }
        var productToUpdate = this.repositoryManager.ProductRepository.FindByCondition(p => p.Id.Equals(id)).FirstOrDefault();

        if (productToUpdate == null)
        {
            return (null, false, "Product does not exist.");
        }

        productToUpdate.Name = product.Name;
        productToUpdate.PurchasePrice = product.PurchasePrice;
        productToUpdate.Manufacturer = product.Manufacturer;
        productToUpdate.Style = product.Manufacturer;
        productToUpdate.UpdatedAt = DateTimeOffset.UtcNow;
        productToUpdate.QtyOnHand = product.QtyOnHand;
        productToUpdate.CommissionPercentage = product.CommissionPercentage;
        productToUpdate.SalePrice = product.SalePrice;

        this.repositoryManager.ProductRepository.Update(productToUpdate);
        await this.repositoryManager.SaveChangesAsync();

        return (product, true, string.Empty);
    }
}
