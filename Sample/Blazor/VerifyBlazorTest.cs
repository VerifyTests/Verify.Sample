using BlazorWebApp.Pages;
using VerifyTests.Blazor;
using Counter = BlazorWebApp.Pages.Counter;

[UsesVerify]
public class VerifyBlazorTest
{
    [Fact]
    public Task RenderCounter_Web()
    {
        var target = Render.Component<Counter>(
            callback: component => { component.IncrementCount(); });
        return Verify(target);
    }
}