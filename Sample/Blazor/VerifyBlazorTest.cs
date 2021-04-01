using System.Threading.Tasks;
using VerifyTests.Blazor;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class VerifyBlazorTest
{
    [Fact]
    public Task RenderCounter_Web()
    {
        var target = Render.Component<BlazorWebApp.Pages.Counter>(
            beforeRender: component => { component.IncrementCount(); });
        return Verifier.Verify(target);
    }
}