[UsesVerify]
public class PersonBuilderTestsVerify
{
    static VerifySettings verifySettings;

    static PersonBuilderTestsVerify()
    {
        verifySettings = new();
        verifySettings.ScrubInlineGuids();
        verifySettings.IgnoreMember<Person>(target => target.Age);
    }

    [Fact]
    public async Task Find()
    {
        var id = new Guid("ebced679-45d3-4653-8791-3d969c4a986c");
        var person = PersonBuilder.Find(id)!;
        await Verify(person, verifySettings);
        Assert.Equal((DateTime.Now - person.DateOfBirth).TotalDays, person.Age.TotalDays, 1);
    }

    [Fact]
    public async Task FindAll()
    {
        var people = PersonBuilder.FindAll().ToList();
        await Verify(people, verifySettings);
    }
}