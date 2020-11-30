using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace WebApi.Modules.Common
{
    public static class CustomControllersExtensions
    {

        public static IServiceCollection AddCustomContollers(this IServiceCollection services)
        {
            services
                .AddMvc();

            services
                .AddHttpContextAccessor()
                .AddControllers()
                .AddControllersAsServices();
            return services;
        }
    }
}
