using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Adyen.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Adyen.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class AdyenOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="IAdyenOpenApiHttpClient"/> as a singleton service backed by the singleton HTTP-client cache.
    /// </summary>
    public static IServiceCollection AddAdyenOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IAdyenOpenApiHttpClient, AdyenOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IAdyenOpenApiHttpClient"/> as a scoped service backed by the singleton HTTP-client cache.
    /// </summary>
    public static IServiceCollection AddAdyenOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IAdyenOpenApiHttpClient, AdyenOpenApiHttpClient>();

        return services;
    }
}
