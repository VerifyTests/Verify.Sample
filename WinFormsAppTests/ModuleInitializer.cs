using System.Runtime.CompilerServices;
using VerifyTests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifyImageMagick.RegisterComparers(.01);
        VerifyWinForms.Enable();
    }
}