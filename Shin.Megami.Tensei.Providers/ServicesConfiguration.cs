using Shin.Megami.Tensei.Providers.Interfaces;
using Shin.Megami.Tensei.Providers.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Shin.Megami.Tensei.Providers
{
    /// <summary>
    /// This class provides configuration options for provider services.
    /// </summary>
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services.AddScoped<IProductProvider, ProductProvider>();
            services.AddScoped<IEncounterProvider, EncounterProvider>();

            return services;
        }
    }
}
