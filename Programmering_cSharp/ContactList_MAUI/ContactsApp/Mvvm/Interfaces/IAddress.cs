namespace ContactsApp.Interfaces;

public interface IAddress
{
    string StreetName { get; set; }
    string StreetNumber { get; set; }
    string ZipCode { get; set; }
    string City { get; set; }

    string FullAddress => $"{StreetName} {StreetNumber}, {ZipCode} {City}";
}