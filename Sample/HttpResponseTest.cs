[UsesVerify]
public class HttpResponseTest
{
    static HttpClient client = new();

    [Fact]
    public async Task ImageHttpResponse()
    {
        var result = await client.GetAsync("https://raw.githubusercontent.com/VerifyTests/Verify/main/src/icon.png");

        await Verify(result);
    }

    [Fact]
    public async Task HttpResponse()
    {
        var result = await client.GetAsync("https://raw.githubusercontent.com/VerifyTests/Verify/main/license.txt");

        await Verify(result);
    }
}