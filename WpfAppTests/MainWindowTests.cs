using WpfApp;

[Apartment(ApartmentState.STA)]
[TestFixture]
public class MainWindowTests
{
    [Test]
    public async Task WindowUsage()
    {
        var window = new MainWindow();
        await Verify(window);
    }
}