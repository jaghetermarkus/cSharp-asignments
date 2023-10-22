using System;
using ContactsApp.Mvvm.Models;

namespace ContactsApp.Interfaces;

public interface IContactModel
{
    Guid Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string PhoneNumber { get; set; }
    DateTime Created { get; set; }

    Address Address { get; set; }

    string FullName => $"{FirstName} {LastName}";

}