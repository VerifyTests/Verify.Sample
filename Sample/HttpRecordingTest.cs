using VerifyTests.Http;

[UsesVerify]
public class HttpRecordingTest
{
    [Fact]
    public async Task TestHttpRecording()
    {
        HttpRecording.StartRecording();

        var sizeOfResponse = await MethodThatDoesHttpCalls();

        await Verify(sizeOfResponse)
            .ModifySerialization(
                x => x.IgnoreMember("Date"));
    }

    static async Task<int> MethodThatDoesHttpCalls()
    {
        using var client = new HttpClient();

        var json = await client.GetStringAsync("https://httpbin.org/json");
        var xml = await client.GetStringAsync("https://httpbin.org/xml");
        return json.Length + xml.Length;
    }
}