﻿using System.Threading.Tasks;
using PlaywrightSharp;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class BrowserTest :
    IClassFixture<PlaywrightFixture>
{
    IPage page;

    public BrowserTest(PlaywrightFixture fixture)
    {
        page = fixture.Page;
    }

    [Fact]
    public async Task RenderIndex()
    {
        await page.GoToAsync("http://localhost:5000/");
        await page.WaitForLoadStateAsync(LifecycleEvent.Networkidle);
        await Verifier.Verify(page);
    }
}