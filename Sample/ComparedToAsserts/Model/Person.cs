using System;

record Person(
    Guid Id,
    string GivenNames,
    string FamilyName,
    DateTime DateOfBirth,
    Address Address)
{
    public string Description => $"{GivenNames} {FamilyName} ({Id})";
    public TimeSpan Age => DateTime.Now - DateOfBirth;
}