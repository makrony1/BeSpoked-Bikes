using BSB.BL.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class BlServiceExtension
{
    public static void AddBlServices(this IServiceCollection services)
    {
        services.AddTransient<ICustomerService, CustomerServcie>();
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<ISalespersonService, SalespersonService>();
        services.AddTransient<ISalesServcie, SalesServcie>();
    }
}