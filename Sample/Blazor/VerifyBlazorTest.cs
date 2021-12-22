using BlazorWebApp.Pages;
using VerifyTests.Blazor;

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