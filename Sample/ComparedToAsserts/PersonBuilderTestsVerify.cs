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
        var person = PersonBuilder.Find(id)!;
        Assert.Equal((DateTime.Now - person.DateOfBirth).TotalDays, person.Age.TotalDays, 1);
        await Verifier.Verify(person)
            .ScrubInlineGuids()
            .ModifySerialization(
                settings => settings.IgnoreMember<Person>(target => target.Age));
    }

    [Fact]
    public async Task FindAll()
    {
        var people = PersonBuilder.FindAll().ToList();
        await Verifier.Verify(people)
            .ScrubInlineGuids()
            .ModifySerialization(
                settings => settings.IgnoreMember<Person>(target => target.Age));
    }
}