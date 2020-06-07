using System;
using System.Linq;
using Xunit;

[TestFixture]
public class PersonBuilderTests
{
    [Test]
    public void Find()
    {
        var id = new Guid("ebced679-45d3-4653-8791-3d969c4a986c");
        var person = PersonBuilder.Find(id);
        Assert.NotNull(person);
        Assert.Equal(id, person.Id);
        Assert.Equal("Emmy", person.GivenNames);
        Assert.Equal("Annachiara", person.FamilyName);
        Assert.Equal(new DateTime(2000, 1, 2, 3, 0, 0), person.DateOfBirth);
        var address = person.Address;
        Assert.NotNull(address);
        Assert.Equal("924 Jehovah Drive", address.Street);
        Assert.Equal("Strasburg", address.City);
        Assert.Equal("Virginia", address.State);
    }

    [Test]
    public void FindAll()
    {
        var people = PersonBuilder.FindAll().ToList();
        Assert.NotNull(people);
        Assert.Equal(2, people.Count);
        var person0 = people[0];
        Assert.NotNull(person0);
        Assert.Equal("Emmy", person0.GivenNames);
        Assert.Equal("Annachiara", person0.FamilyName);
        //TODO: assert other person0 properties
        var person1 = people[1];
        Assert.NotNull(person1);
        Assert.Equal("Javed", person1.GivenNames);
        Assert.Equal("Sargis", person1.FamilyName);
        //TODO: assert other person1 properties
    }
}