using System;
using System.Collections.Generic;
using System.Linq;
using ContactsApp.Interfaces;
using ContactsApp.Mvvm.Models;
using Newtonsoft.Json;

namespace ContactsApp.Services;

public class ContactService : IContactService
{
    private static readonly string filePath = @"/Users/markuskarlsson/Nackademin/cSharp/assignments/Programmering_cSharp/ContactList_MAUI/ContactsApp/ListOfContacts.Json";
    private static List<ContactModel> contacts = new List<ContactModel>();
    private JsonService _jsonService = new JsonService();
    public static event Action ContactsUpdated;


    // Tar emot och lägger till ny kontakt i lista samt Json-fil
    public void AddToList(ContactModel contact)
    {
        contacts.Add(contact);
        WhenContactsUpdated();
    }

    // Hämtar alla kontakter från Json-fil och tilldelar i lokala listan
    public List<ContactModel> GetContacts()
    {
        var content = _jsonService.ReadFromJson(filePath);
        if (!string.IsNullOrEmpty(content))
            contacts = JsonConvert.DeserializeObject<List<ContactModel>>(content)!;

        return contacts;
    }

    // Tar bort kontakt från listan samt uppdaterar Json-fil och gränssnitt
    public void DeleteContact(ContactModel contact)
    {
        if (contact != null)
            contacts.Remove(contact);

        WhenContactsUpdated();
    }

    // Hämtar ut specifik kontakt från listan utefter Id
    public static ContactModel GetOneContact(string contactId)
    {
        if (Guid.TryParse(contactId, out var GuidcontactId))
            return contacts.FirstOrDefault(x => x.Id == GuidcontactId);

        return null;
    }

    // Skickar in uppdaterad kontakt och uppdaterar lokal lista samt Json-fil. 
    public void SaveUpdatedContact(ContactModel updatedContact)
    {
        /* Kod behövs inte för uppdatering. Listan uppdaterad direkt när kontakten tas emot av metoden.
        ContactModel existingContact = contacts.FirstOrDefault(x => x.Id == updatedContact.Id);

        if (existingContact != null)
        {
            // mapper.Map(updatedContact, existingContact);
            existingContact.FirstName = updatedContact.FirstName;
            existingContact.LastName = updatedContact.LastName;
            existingContact.Email = updatedContact.Email;
            existingContact.PhoneNumber = updatedContact.PhoneNumber;
        }
        */
        WhenContactsUpdated();
    }

    // Sparar ner ändringar till Json-fil samt uppdaterar gränssnitt via Invoke...
    protected virtual void WhenContactsUpdated()
    {
        _jsonService.SaveToJson(JsonConvert.SerializeObject(contacts), filePath);
        ContactsUpdated?.Invoke();
    }

}