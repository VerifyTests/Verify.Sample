using System.Runtime.CompilerServices;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifyHttp.Enable();
        VerifyImageMagick.RegisterComparers(.01);
        VerifyImageSharp.Initialize();
        VerifyDiffPlex.Initialize();

        VerifierSettings.IgnoreMembers(
                "traceparent",
                "X-Amzn-Trace-Id",
                "origin",
                "Content-Length");
    }
}