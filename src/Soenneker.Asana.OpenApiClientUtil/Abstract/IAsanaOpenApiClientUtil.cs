using Soenneker.Asana.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Asana.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IAsanaOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<AsanaOpenApiClient> Get(CancellationToken cancellationToken = default);
}
