﻿using System.Runtime.CompilerServices;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifyImageMagick.RegisterComparers(.4);
        VerifyWinForms.Enable();
        VerifyDiffPlex.Initialize();
    }
}