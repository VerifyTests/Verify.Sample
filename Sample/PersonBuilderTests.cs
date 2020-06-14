using System;
using System.Linq;
using Xunit;

public class PersonBuilderTests
{
    [Fact]
    public void Find()
    {
        var id = new Guid("ebced679-45d3-4653-8791-3d969c4a986c");
        var person = PersonBuilder.Find(id);
        Assert.NotNull(person);
        Assert.AreEqual(id, person.Id);
        Assert.AreEqual("Emmy", person.GivenNames);
        Assert.AreEqual("Annachiara", person.FamilyName);
        Assert.AreEqual(new DateTime(2000, 1, 2, 3, 0, 0), person.DateOfBirth);
        var address = person.Address;
        Assert.NotNull(address);
        Assert.AreEqual("924 Jehovah Drive", address.Street);
        Assert.AreEqual("Strasburg", address.City);
        Assert.AreEqual("Virginia", address.State);
    }

    [Fact]
    public void FindAll()
    {
        var people = PersonBuilder.FindAll().ToList();
        Assert.NotNull(people);
        Assert.AreEqual(2, people.Count);
        var person0 = people[0];
        Assert.NotNull(person0);
        Assert.AreEqual("Emmy", person0.GivenNames);
        Assert.AreEqual("Annachiara", person0.FamilyName);
        //TODO: assert other person0 properties
        var person1 = people[1];
        Assert.NotNull(person1);
        Assert.AreEqual("Javed", person1.GivenNames);
        Assert.AreEqual("Sargis", person1.FamilyName);
        //TODO: assert other person1 properties
    }
}