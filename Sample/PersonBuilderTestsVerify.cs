using System;
using System.Linq;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class PersonBuilderTestsVerify
{
    [Fact]
    public async Task Find()
    {
        var id = new Guid("ebced679-45d3-4653-8791-3d969c4a986c");
        var person = PersonBuilder.Find(id);
        await Verifier.Verify(person);
    }

    [Fact]
    public async Task FindAll()
    {
        var people = PersonBuilder.FindAll().ToList();
        await Verifier.Verify(people);
    }
}