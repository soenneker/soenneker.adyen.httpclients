using Soenneker.Adyen.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Adyen.HttpClients.Tests;

[Collection("Collection")]
public sealed class AdyenOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IAdyenOpenApiHttpClient _httpclient;

    public AdyenOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IAdyenOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
