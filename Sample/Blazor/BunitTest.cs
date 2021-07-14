using Bunit;
using BlazorWebApp.Pages;
using Xunit;

public class BunitTest
{
    [Fact]
    public void RenderCounter_Web()
    {
        // Arrange: render the Counter.razor component
        using var context = new TestContext();
        var component = context.RenderComponent<Counter>();

        // Act: find and click the <button> element to increment
        // the counter in the <p> element
        component.Find("button")
            .Click();

        // Assert: first find the <p> element, then verify its content
        component.Find("p")
            .MarkupMatches("<p>Current count: 1</p>");
    }
}