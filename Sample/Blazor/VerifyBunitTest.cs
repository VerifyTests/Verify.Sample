using System.Threading.Tasks;
using Bunit;
using VerifyTests;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class VerifyBunitTest
{
    static VerifyBunitTest()
    {
        VerifyBunit.Initialize();
    }

    [Fact]
    public Task RenderCounter_Web()
    {
        // Arrange: render the Counter.razor component
        using var context = new TestContext();
        var component = context.RenderComponent<BlazorWebApp.Pages.Counter>();

        // Act: find and click the <button> element to increment
        // the counter in the <p> element
        component.Find("button").Click();

        return Verifier.Verify(component);
    }
}