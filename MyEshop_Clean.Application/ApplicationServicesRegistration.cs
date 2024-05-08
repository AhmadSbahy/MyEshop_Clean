using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MyEshop_Clean.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationRegisterServices<TClass>(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(TClass).Assembly));
        }
    }
}
