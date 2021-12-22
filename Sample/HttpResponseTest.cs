[UsesVerify]
public class HttpResponseTest
{
    static HttpClient client = new();

    [Fact]
    public async Task ImageHttpResponse()
    {
        var result = await client.GetAsync("https://httpbin.org/image/png");

        await Verify(result);
    }

    [Fact]
    public async Task HttpResponse()
    {
        var result = await client.GetAsync("https://httpbin.org/get");

        await Verify(result);
    }
}