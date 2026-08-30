using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Adyen.HttpClients.Abstract;

/// <summary>
/// Provides the cached, configured <see cref="HttpClient"/> used by the Adyen OpenAPI client.
/// </summary>
public interface IAdyenOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the shared named HTTP client, creating and configuring it on first use.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel client creation.</param>
    /// <returns>The cached HTTP client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
