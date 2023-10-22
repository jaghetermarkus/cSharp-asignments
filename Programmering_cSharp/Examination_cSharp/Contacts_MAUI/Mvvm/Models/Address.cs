using Contacts_MAUI.Interfaces;

namespace Contacts_MAUI.Mvvm.Models;

public class Address : IAddress
{
    public string StreetName { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string City { get; set; } = null!;

    public string FullAddress => $"{StreetName} {StreetNumber}, {ZipCode} {City}";

}

