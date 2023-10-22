using System.Collections.Generic;
using ContactsApp.Mvvm.Models;

namespace ContactsApp.Interfaces;

public interface IContactService
{
    void AddToList(ContactModel contact);
    List<ContactModel> GetContacts();
    void DeleteContact(ContactModel contact);
    void SaveUpdatedContact(ContactModel updatedContact);

    // static ContactModel GetOneContact(string contactId);
    // void WhenContactsUpdated();

}