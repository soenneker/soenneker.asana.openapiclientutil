using Soenneker.Asana.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Asana.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class AsanaOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IAsanaOpenApiClientUtil _openapiclientutil;

    public AsanaOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IAsanaOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
