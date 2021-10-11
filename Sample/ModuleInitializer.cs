using System.Runtime.CompilerServices;
using VerifyTests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifyHttp.Enable();
        VerifyImageMagick.RegisterComparers(.01);

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