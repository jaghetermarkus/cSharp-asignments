using _01_ContactList.Interfaces;

namespace _01_ContactList.Models;

public class Contact : IContact
{
    public int MemberID { get; set; }
    public Guid Id { get; set; } = Guid.NewGuid(); // Ska tilldelningen ligga i MenuService istället ???
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime Created { get; set; } = DateTime.Now; // Samma fråga om Guid ovan ???

    public Address? Address { get; set; }

    public string? FullName => $"{FirstName} {LastName}";

}

