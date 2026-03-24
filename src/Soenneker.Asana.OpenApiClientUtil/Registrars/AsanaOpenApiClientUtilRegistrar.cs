using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Asana.HttpClients.Registrars;
using Soenneker.Asana.OpenApiClientUtil.Abstract;

namespace Soenneker.Asana.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class AsanaOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="AsanaOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddAsanaOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddAsanaOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IAsanaOpenApiClientUtil, AsanaOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="AsanaOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddAsanaOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddAsanaOpenApiHttpClientAsSingleton()
                .TryAddScoped<IAsanaOpenApiClientUtil, AsanaOpenApiClientUtil>();

        return services;
    }
}
