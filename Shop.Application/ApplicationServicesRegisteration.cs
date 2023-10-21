using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Shop.Application
{
    public static class ApplicationServicesRegisteration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            //2 rah vojod darad baraye config
            //1- services.AddAutoMapper(typeof(MappingProfile));
            //2-
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
