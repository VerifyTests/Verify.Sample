public class HttpRecordingTest
{
    [Fact]
    public async Task TestHttpRecording()
    {
        Recording.Start();

        var sizeOfResponse = await MethodThatDoesHttpCalls();

        await Verify(sizeOfResponse)
            .IgnoreMembers("Date", "Expires");
    }

    static async Task<int> MethodThatDoesHttpCalls()
    {
        using var client = new HttpClient();

        var json = await client.GetStringAsync("https://raw.githubusercontent.com/VerifyTests/Verify/main/src/icon.png");
        var xml = await client.GetStringAsync("https://raw.githubusercontent.com/VerifyTests/Verify/main/license.txt");
        return json.Length + xml.Length;
    }
}