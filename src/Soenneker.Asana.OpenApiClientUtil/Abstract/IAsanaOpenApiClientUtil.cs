using Soenneker.Asana.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Asana.OpenApiClientUtil.Abstract;

/// <summary>
/// Creates and caches an authenticated <see cref="AsanaOpenApiClient"/>.
/// </summary>
public interface IAsanaOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached client, creating it on first use.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel initial client creation.</param>
    /// <returns>The cached generated client.</returns>
    ValueTask<AsanaOpenApiClient> Get(CancellationToken cancellationToken = default);
}
