using Microsoft.Extensions.DependencyInjection;
using OpenTrade.Logic.Services;

namespace OpenTrade.Logic.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddFibonacciServices(this IServiceCollection services)
        {
            services.AddScoped<IFibonacciHandler, FibonacciHandler>();
            return services;
        }
    }
}
