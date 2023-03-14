using GpgDecryptionApp.Services;
using GpgDecryptionApp.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GpgDecryptionApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDecryptionService(this IServiceCollection services)
        {
            return services.AddSingleton<IDecryptionService, GpgDecryptionService>();
        }
    }
}
