using BSB.BL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection;

public static class BlServiceExtension
{
    public static void AddBlServices(this IServiceCollection services)
    {
        services.AddTransient<ICustomerService, CustomerServcie>();
    }
}