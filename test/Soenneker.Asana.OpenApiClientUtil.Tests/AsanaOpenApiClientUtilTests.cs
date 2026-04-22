using Soenneker.Asana.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Asana.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class AsanaOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IAsanaOpenApiClientUtil _openapiclientutil;

    public AsanaOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IAsanaOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
