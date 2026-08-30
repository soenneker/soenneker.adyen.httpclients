[![](https://img.shields.io/nuget/v/soenneker.adyen.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.adyen.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.adyen.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.adyen.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.adyen.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.adyen.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.adyen.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.adyen.httpclients/actions/workflows/codeql.yml)

# Soenneker.Adyen.HttpClients

Provides a cached, configured `HttpClient` for the Adyen OpenAPI client.

## Installation

```bash
dotnet add package Soenneker.Adyen.HttpClients
```

## Configuration

```json
{
  "Adyen": {
    "ApiKey": "your-api-key",
    "ClientBaseUrl": "https://your-adyen-endpoint/",
    "AuthHeaderName": "X-API-Key",
    "AuthHeaderValueTemplate": "{token}"
  }
}
```

`Adyen:ApiKey` is required. The other settings are optional:

- `ClientBaseUrl` overrides the client's base address.
- `AuthHeaderName` defaults to `Authorization`.
- `AuthHeaderValueTemplate` defaults to `Bearer {token}`; `{token}` is replaced with `ApiKey`.

Set the header name and template to the authentication format required by the Adyen API you are calling.

## Registration

```csharp
using Soenneker.Adyen.HttpClients.Registrars;

services.AddAdyenOpenApiHttpClientAsSingleton();
```

`AddAdyenOpenApiHttpClientAsScoped()` is also available. Both registrations use the singleton HTTP-client cache, so scopes reuse the same named client.

## Usage

```csharp
using Soenneker.Adyen.HttpClients.Abstract;

public sealed class AdyenRequestService
{
    private readonly IAdyenOpenApiHttpClient _clientProvider;

    public AdyenRequestService(IAdyenOpenApiHttpClient clientProvider)
    {
        _clientProvider = clientProvider;
    }

    public async Task<HttpResponseMessage> Send(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        HttpClient client = await _clientProvider.Get(cancellationToken);
        return await client.SendAsync(request, cancellationToken);
    }
}
```

`Get()` returns the cached named client. Configuration is applied when that client is first created; changing configuration afterward does not rebuild it.

The dependency-injection container owns resolved providers. Disposing a provider removes and disposes its named `HttpClient` from the shared cache.
