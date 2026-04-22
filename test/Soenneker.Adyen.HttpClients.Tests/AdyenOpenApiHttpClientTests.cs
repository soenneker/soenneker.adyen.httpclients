using Soenneker.Adyen.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Adyen.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class AdyenOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IAdyenOpenApiHttpClient _httpclient;

    public AdyenOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IAdyenOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
