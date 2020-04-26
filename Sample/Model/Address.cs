class Address
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }

    public Address(
        string street,
        string city,
        string state)
    {
        Street = street;
        City = city;
        State = state;
    }
}