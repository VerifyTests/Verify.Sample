using System.Net.Http;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class HttpResponseTest
{
    [Fact]
    public async Task ImageHttpResponse()
    {
        using HttpClient client = new();

        var result = await client.GetAsync("https://httpbin.org/image/png");

        await Verifier.Verify(result);
    }

    [Fact]
    public async Task HttpResponse()
    {
        using HttpClient client = new();

        var result = await client.GetAsync("https://httpbin.org/get");

        await Verifier.Verify(result);
    }
}