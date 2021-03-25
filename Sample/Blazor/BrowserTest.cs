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
        await page.GoToAsync("https://localhost:5001/");
        await page.WaitForLoadStateAsync();
        await Verifier.Verify(page);
    }
}