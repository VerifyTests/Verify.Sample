using System.Runtime.CompilerServices;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifyHttp.Enable();
        VerifyImageMagick.RegisterComparers(.01);
        VerifyImageSharp.Initialize();

        VerifierSettings.ModifySerialization(settings =>
        {
            settings.IgnoreMembers(
                "traceparent",
                "Traceparent",
                "X-Amzn-Trace-Id",
                "origin",
                "Content-Length",
                "TrailingHeaders");
        });
    }
}