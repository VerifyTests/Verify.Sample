using System.Threading.Tasks;
using BlazorWebApp.Pages;
using VerifyTests.Blazor;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class VerifyBunitTest
{
    [Fact]
    public async Task RenderCounter()
    {
        var target = Render.Component<Counter>(
            beforeRender: component =>
            {
                component.IncrementCount();
            });
        await Verifier.Verify(target);
    }
}