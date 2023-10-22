using System.Collections;
using System.Diagnostics;
using _01_ContactList.Interfaces;
using _01_ContactList.Models;
using Newtonsoft.Json;

namespace _01_ContactList.Services;

public class ContactService : IContactService
{

    private List<IContact> _list = new();

    public bool AddContact(IContact contact)
    {
        try
        {
            //_list = GetAllContacts();
            _list.Add(contact);
        JsonService.SaveToJson(JsonConvert.SerializeObject(_list));

            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public IContact GetOneContact(int memberId)
    {
        try
        {
            return _list.FirstOrDefault(x => x.MemberID == memberId)!;
        }
        catch { }
            return null!;
    }

    public bool DeleteContact(int memberId)
    {
        try
        {
            var contact = GetOneContact(memberId);
            _list.Remove(contact!);
            JsonService.SaveToJson(JsonConvert.SerializeObject(_list));
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
    }

    public IEnumerable<IContact> GetAllContacts()
    {
        try
        {
            ClearAllContacts();
            var content = JsonService.ReadFromJson();

            if (!string.IsNullOrEmpty(content)) 
            {
                foreach (var contact in JsonConvert.DeserializeObject<List<Contact>>(content)!) 
                    _list.Add(contact);
            }

            return _list;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public int HighestMemberId()
    {
        int id = _list.Any() ? _list.Max(contact => contact.MemberID + 1) : 1;
        return id;
    }

    public IEnumerable<IContact> ClearAllContacts()
    {
        _list.Clear();
        return _list;
    }

    public void ListContacts()
    {
        Console.WriteLine("--- KONTAKTLISTA ---");
        Console.WriteLine("---------------------");
        foreach (var contact in GetAllContacts())
        {
            Console.WriteLine($"Medlemsnr: {contact.MemberID}\t{contact.FullName}   <{contact.Email}>");
        }
    }

}

