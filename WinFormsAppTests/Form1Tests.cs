using System.Threading;
using System.Threading.Tasks;
using VerifyNUnit;
using NUnit.Framework;
using SimpleCalculator;

[TestFixture]
[Apartment(ApartmentState.STA)]
public class Form1Tests
{
    [Test]
    public async Task FormUsage()
    {
        var form = new Form1();
        await Verifier.Verify(form);
    }
}