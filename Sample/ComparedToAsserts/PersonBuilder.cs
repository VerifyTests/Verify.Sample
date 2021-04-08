using System;
using System.Collections.Generic;
using System.Linq;

class PersonBuilder
{
    public static List<Person> People = new()
    {
        new(
            Id: new Guid("ebced679-45d3-4653-8791-3d969c4a986c"),
            GivenNames: "Emmy",
            FamilyName: "Annachiara",
            DateOfBirth: new DateTime(2000, 1, 2, 3, 0, 0),
            Address: new Address(
                street: "924 Jehovah Drive",
                city: "Strasburg",
                state: "Virginia")),
        new(
            Id: new Guid("7e6e1c62-92f2-4b64-8a85-988107458606"),
            GivenNames: "Javed",
            FamilyName: "Sargis",
            DateOfBirth: new DateTime(1998, 4, 2, 5, 0, 0),
            Address: new Address(
                street: "1587 Elliott Street",
                city: "Manchester",
                state: "New Hampshire"))
    };

    public static Person? Find(Guid id)
    {
        return People.SingleOrDefault(x => x.Id == id);
    }

    public static IEnumerable<Person> FindAll()
    {
        return People;
    }
}