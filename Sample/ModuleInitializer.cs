using System.Runtime.CompilerServices;
using VerifyTests.Http;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifyHttp.Initialize();
        VerifyImageMagick.RegisterComparers(.01);
        VerifyImageSharp.Initialize();
        VerifyDiffPlex.Initialize();
        HttpRecording.Enable();
        VerifierSettings.IgnoreMembers(
            "Content-Length",
            "traceparent",
            "Traceparent",
            "X-Amzn-Trace-Id",
            "X-GitHub-Request-Id",
            "origin",
            "Date",
            "Server",
            "X-Fastly-Request",
            "Source-Age",
            "X-Fastly-Request-ID",
            "X-Served-By",
            "X-Cache-Hits",
            "X-Served-By",
            "X-Cache",
            "Content-Length",
            "X-Timer");
        VerifierSettings
            .ScrubLinesContaining(
                "Traceparent",
                "Date",
                "X-Amzn-Trace-Id",
                "Content-Length");
    }
}