using System.Threading.Tasks;
using PlaywrightSharp;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class BlazorIntegrationTest :
    IClassFixture<PlaywrightFixture>
{
    IPage page;

    public BlazorIntegrationTest(PlaywrightFixture fixture)
    {
        page = fixture.Page;
    }

    [Fact]
    public async Task RenderIndex()
    {
        await page.GoToAsync("https://localhost:5001/");
        await page.WaitForLoadStateAsync(LifecycleEvent.Networkidle);
        await Verifier.Verify(page);
    }
}