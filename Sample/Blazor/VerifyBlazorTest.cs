using System.Threading.Tasks;
using BlazorWebApp.Pages;
using VerifyTests.Blazor;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class VerifyBlazorTest
{
    [Fact]
    public Task RenderCounter_Web()
    {
        var target = Render.Component<Counter>(
            callback: component => { component.IncrementCount(); });
        return Verifier.Verify(target);
    }
}