using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Asana.HttpClients.Abstract;
using Soenneker.Asana.OpenApiClientUtil.Abstract;
using Soenneker.Asana.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Asana.OpenApiClientUtil;

///<inheritdoc cref="IAsanaOpenApiClientUtil"/>
public sealed class AsanaOpenApiClientUtil : IAsanaOpenApiClientUtil
{
    private readonly AsyncSingleton<AsanaOpenApiClient> _client;

    public AsanaOpenApiClientUtil(IAsanaOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<AsanaOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Asana:ApiKey");
            string authHeaderValueTemplate = configuration["Asana:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

            return new AsanaOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<AsanaOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
