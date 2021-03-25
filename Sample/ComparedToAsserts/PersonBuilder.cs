using System;
using System.Collections.Generic;
using System.Linq;

static class PersonBuilder
{
    static List<Person> people = new()
    {
        new(
            id: new Guid("ebced679-45d3-4653-8791-3d969c4a986c"),
            givenNames: "Emmy",
            familyName: "Annachiara",
            dateOfBirth: new DateTime(2000, 1, 2, 3, 0, 0),
            age: 20,
            address: new Address(
                street: "924 Jehovah Drive",
                city: "Strasburg",
                state: "Virginia")),
        new(
            id: new Guid("7e6e1c62-92f2-4b64-8a85-988107458606"),
            givenNames: "Javed",
            familyName: "Sargis",
            dateOfBirth: new DateTime(1998, 4, 2, 5, 0, 0),
            age: 25,
            address: new Address(
                street: "1587 Elliott Street",
                city: "Manchester",
                state: "New Hampshire"))
    };

    public static Person Find(Guid id)
    {
        return people.SingleOrDefault(x => x.Id == id);
    }

    public static IEnumerable<Person> FindAll()
    {
        return people;
    }
}