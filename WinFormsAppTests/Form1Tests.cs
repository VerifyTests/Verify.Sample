using System.Threading.Tasks;
using VerifyNUnit;
using NUnit.Framework;
using SimpleCalculator;

[TestFixture]
public class Form1Tests
{
    [Test]
    //TODO: Make this STA
    public Task FormUsage()
    {
        var form = new Form1();
        return Verifier.Verify(form);
    }
}