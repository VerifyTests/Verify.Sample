using System;

class Person
{
    public Guid Id { get; }
    public string GivenNames { get; }
    public string FamilyName { get; }
    public DateTime DateOfBirth { get; }
    public int Age { get; }
    public Address Address { get; }

    public Person(
        Guid id,
        string givenNames,
        string familyName,
        DateTime dateOfBirth,
        int age,
        Address address)
    {
        Id = id;
        GivenNames = givenNames;
        FamilyName = familyName;
        DateOfBirth = dateOfBirth;
        Age = age;
        Address = address;
    }
}