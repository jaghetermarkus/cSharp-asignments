using _01_ContactList.Models;

namespace _01_ContactList.Interfaces;

public interface IContact
{
    int MemberID { get; set; }
    Guid Id { get; set; }
    string? FirstName { get; set; }
    string? LastName { get; set; }
    string? Email { get; set; }
    DateTime Created { get; set; }
    Address? Address { get; set; }
    string? FullName { get; }

}

