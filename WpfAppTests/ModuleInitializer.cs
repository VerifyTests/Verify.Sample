using System.Runtime.CompilerServices;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifyImageMagick.RegisterComparers(.05);
        VerifyXaml.Initialize();
        VerifyDiffPlex.Initialize();
    }
}