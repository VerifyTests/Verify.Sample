using System.Net.Http;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class HttpResponseTest
{
    static HttpClient client = new();

    [Fact]
    public async Task ImageHttpResponse()
    {
        var result = await client.GetAsync("https://httpbin.org/image/png");

        await Verifier.Verify(result);
    }

    [Fact]
    public async Task HttpResponse()
    {
        var result = await client.GetAsync("https://httpbin.org/get");

        await Verifier.Verify(result);
    }
}