using System.ComponentModel;
using System.Threading.Tasks;
using PlaywrightSharp;
using VerifyXunit;
using Xunit;

[UsesVerify]
[Category("Integration")]
public class BrowserTest :
    IClassFixture<PlaywrightFixture>
{
    IPage page;

    public BrowserTest(PlaywrightFixture fixture)
    {
        page = fixture.Page;
    }

    [Fact]
    public async Task Index()
    {
        await page.GoToAsync("http://localhost:5000/");
        await page.WaitForLoadStateAsync(LifecycleEvent.Networkidle);
        await Verifier.Verify(page);
    }

    [Fact]
    public async Task Counter()
    {
        await page.GoToAsync("http://localhost:5000/counter");
        await page.WaitForLoadStateAsync(LifecycleEvent.Networkidle);
        var element = await page.QuerySelectorAsync(".content");
        await Verifier.Verify(element);
    }
}