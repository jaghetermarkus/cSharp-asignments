using _01_ContactList.Models;

namespace _01_ContactList.Interfaces;

public interface IContactService
{
    bool AddContact(IContact contact);
    IEnumerable<IContact> GetAllContacts();
    IContact GetOneContact(int memberId);
    bool DeleteContact(int memberId);
    int HighestMemberId();
    IEnumerable<IContact> ClearAllContacts();
    void ListContacts();
} 

