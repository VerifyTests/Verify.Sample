using System.Threading;
using System.Threading.Tasks;
using VerifyNUnit;
using NUnit.Framework;
using WpfApp;

[Apartment(ApartmentState.STA)]
[TestFixture]
public class MainWindowTests
{
    [Test]
    public async Task WindowUsage()
    {
        var window = new MainWindow();
        await Verifier.Verify(window);
    }
}