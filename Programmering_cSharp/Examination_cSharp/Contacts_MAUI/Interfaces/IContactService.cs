using Contacts_MAUI.Mvvm.Models;

namespace Contacts_MAUI.Interfaces;

public interface IContactService
{
    void AddToList(ContactModel contact);
    List<ContactModel> GetContacts();
    void DeleteContact(ContactModel contact);
    void SaveUpdatedContact(ContactModel updatedContact);

    // static ContactModel GetOneContact(string contactId);
    // void WhenContactsUpdated();

}

