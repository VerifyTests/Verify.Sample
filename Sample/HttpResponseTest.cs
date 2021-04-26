using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using VerifyTests;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class HttpResponseTest
{
    [ModuleInitializer]
    public static void Init()
    {
        VerifierSettings.ModifySerialization(settings =>
        {
            settings.IgnoreMembers("Traceparent",
                "X-Amzn-Trace-Id",
                "origin",
                "Content-Length",
                "TrailingHeaders");
        });
    }

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