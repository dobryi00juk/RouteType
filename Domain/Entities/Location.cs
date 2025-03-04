namespace Domain.Entities;

public class Location : Entity
{
    public string City { get; private set; }
    public string Street { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }
    public string Country { get; private set; }

    public Location(string city, string street, string state, string postalCode, string country)
    {
        City = city;
        Street = street;
        State = state;
        PostalCode = postalCode;
        Country = country;
    }
}