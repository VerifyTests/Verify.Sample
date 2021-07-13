using System.Threading;
using System.Threading.Tasks;
using Tests;
using VerifyNUnit;
using NUnit.Framework;

[Apartment(ApartmentState.STA)]
[TestFixture]
public class TheTests
{
    [Test]
    public async Task WindowUsage()
    {
        var window = new MyWindow();
        await Verifier.Verify(window);
    }
}