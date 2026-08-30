[![](https://img.shields.io/nuget/v/soenneker.asana.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.asana.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.asana.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.asana.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.asana.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.asana.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.asana.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.asana.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Asana.OpenApiClientUtil

Creates and caches an authenticated `AsanaOpenApiClient` for dependency-injected applications.

## Installation

```bash
dotnet add package Soenneker.Asana.OpenApiClientUtil
```

## Configuration

```json
{
  "Asana": {
    "ApiKey": "your-personal-access-token"
  }
}
```

`Asana:ApiKey` is required. The default base URL is `https://app.asana.com/api/1.0`, and the default authentication format is `Authorization: Bearer {token}`. `Asana:ClientBaseUrl`, `Asana:AuthHeaderName`, and `Asana:AuthHeaderValueTemplate` can override those values.

## Registration

```csharp
using Soenneker.Asana.OpenApiClientUtil.Registrars;

services.AddAsanaOpenApiClientUtilAsScoped();
```

The scoped utility uses a singleton HTTP-client provider, so ending a scope does not remove the shared cached `HttpClient`. Use `AddAsanaOpenApiClientUtilAsSingleton()` when the generated client should also be shared application-wide.

## Usage

```csharp
using Soenneker.Asana.OpenApiClient;
using Soenneker.Asana.OpenApiClient.Models;
using Soenneker.Asana.OpenApiClientUtil.Abstract;

public sealed class CurrentAsanaUserService
{
    private readonly IAsanaOpenApiClientUtil _clientUtil;

    public CurrentAsanaUserService(IAsanaOpenApiClientUtil clientUtil)
    {
        _clientUtil = clientUtil;
    }

    public async Task<UserResponseData?> Get(CancellationToken cancellationToken = default)
    {
        AsanaOpenApiClient client = await _clientUtil.Get(cancellationToken);
        return await client.Users["me"].GetAsync(cancellationToken: cancellationToken);
    }
}
```

`Get()` lazily creates one generated client per utility instance and returns it afterward. Authentication and base-address configuration are captured during initial creation. Credentials are added only to HTTPS requests and are pinned to the first request host. Let the dependency-injection container dispose resolved utilities.
