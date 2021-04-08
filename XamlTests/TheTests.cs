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
        MyWindow window = new();
        await Verifier.Verify(window);
    }
}