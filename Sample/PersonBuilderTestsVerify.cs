using System;
using System.Linq;
using System.Threading.Tasks;
using VerifyNUnit;
using NUnit.Framework;

[TestFixture]
public class PersonBuilderTestsVerify:VerifyBase
{
    [Test]
    public async Task Find()
    {
        var id = new Guid("ebced679-45d3-4653-8791-3d969c4a986c");
        var person = PersonBuilder.Find(id);
        await Verifier.Verify(person);
    }

    [Test]
    public async Task FindAll()
    {
        var people = PersonBuilder.FindAll().ToList();
        await Verifier.Verify(people);
    }
}