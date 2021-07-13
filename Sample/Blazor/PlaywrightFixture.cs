using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Playwright;
using VerifyTests;
using Xunit;

public class PlaywrightFixture :
    IAsyncLifetime
{
    IPlaywright? playwright;
    Process? process;
    IBrowser? browser;

    public async Task InitializeAsync()
    {
        StartBlazorApp();
        playwright = await Playwright.CreateAsync();

        browser = await playwright.Chromium.LaunchAsync();

        Page = await browser.NewPageAsync();
        var size = Page.ViewportSize!;
        size.Height = 768;
        size.Width = 1024;
    }

    public IPage Page { get; private set; } = null!;

    void StartBlazorApp()
    {
        var projectDir = Path.Combine(AttributeReader.GetSolutionDirectory(), "BlazorWebApp");
        var startInfo = new ProcessStartInfo("dotnet", "run --no-build --no-restore")
        {
            WorkingDirectory = projectDir
        };
        process = Process.Start(startInfo);
    }

    public async Task DisposeAsync()
    {
        if (browser != null)
        {
            await browser.DisposeAsync();
        }

        playwright?.Dispose();

        if (process != null)
        {
            process.Kill();
            process.Dispose();
        }
    }
}