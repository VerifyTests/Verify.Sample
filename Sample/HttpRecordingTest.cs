﻿using System.Net.Http;
using System.Threading.Tasks;
using VerifyTests;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class HttpRecordingTest
{
    [Fact]
    public async Task TestHttpRecording()
    {
        HttpRecording.StartRecording();

        var sizeOfResponse = await MethodThatDoesHttpCalls();

        await Verifier.Verify(sizeOfResponse)
            .ModifySerialization(_ =>
            {
                //scrub some headers that are not consistent between test runs
                _.IgnoreMembers("traceparent", "Date");
            });
    }

    static async Task<int> MethodThatDoesHttpCalls()
    {
        using HttpClient client = new();

        var json = await client.GetStringAsync("https://httpbin.org/json");
        var xml = await client.GetStringAsync("https://httpbin.org/xml");
        return json.Length + xml.Length;
    }
}