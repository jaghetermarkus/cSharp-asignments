using Contacts_MAUI.Interfaces;

namespace Contacts_MAUI.Mvvm.Models;

public class ContactModel : IContactModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public DateTime Created { get; set; } = DateTime.Now;

    public Address Address { get; set; }

    public ContactModel()
    {
        Address = new Address();
    }

    public string FullName => $"{FirstName} {LastName}";

}

