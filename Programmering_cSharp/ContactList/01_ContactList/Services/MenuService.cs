using System.Diagnostics;
using _01_ContactList.Interfaces;
using _01_ContactList.Models;

namespace _01_ContactList.Services;

public class MenuService : IMenuService
{

    private readonly IContactService _contactService = new ContactService();

    public void MainMenu()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("--- KONTAKTLISTA ---");
            Console.WriteLine("---------------------");
            Console.WriteLine("[1] Visa kontaktlista");
            Console.WriteLine("[2] Lägg till kontakt");
            Console.WriteLine("[3] Ta bort kontakt");
            Console.WriteLine("[4] Visa detaljerad kontaktinfo");
            Console.WriteLine("[0] Avsluta program");
            Console.WriteLine();
            Console.Write("Välj ett alternativ i listan: ");
            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    ListAllMenu();
                    break;

                case "2":
                    AddContactMenu();
                    break;

                case "3":
                    DeleteContactMenu();
                    break;

                case "4":
                    ShowOneContactMenu();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }

        } while (true);

    }

    public void ListAllMenu()
    {
        Console.Clear();
        _contactService.ClearAllContacts();
        _contactService.ListContacts();

        /* ALTERNATIV TILL 'ListContacts()'
        Console.WriteLine("--- KONTAKTLISTA ---");
        Console.WriteLine("---------------------");

        foreach (var contact in _contactService.GetAllContacts())
        {
            Console.WriteLine($"Medlemsnr:\t[{contact.MemberID}]");
            Console.WriteLine($"Namn:\t\t{contact.FirstName} {contact.LastName}");
            Console.WriteLine($"E-post:\t\t< {contact.Email} >");
            Console.WriteLine("---------------------");
        }
        */

        Console.WriteLine();
        Console.Write("Tryck valfri knapp för att gå tillbaka till huvudmenyn..");
        Console.ReadKey();

    }

    public void AddContactMenu()
    {
        try
        {
            var answer = "n";
            
            do
            {
                int id = _contactService.HighestMemberId();
                IContact contact = new Contact();

                Console.Clear();
                Console.WriteLine("LÄGG TILL NY KONTAKT");
                Console.Write("Förnamn: ");
                contact.FirstName = Console.ReadLine()!;
                Console.Write("Efternamn: ");
                contact.LastName = Console.ReadLine()!;
                Console.Write("E-postadress: ");
                contact.Email = Console.ReadLine()!.ToLower();

                contact.Address = new Address();
                Console.Write("Gatunamn: ");
                contact.Address.StreetName = Console.ReadLine()!;
                Console.Write("Gatunummer: ");
                contact.Address.StreetNumber = Console.ReadLine()!;
                Console.Write("Postnummer: ");
                contact.Address.PostalCode = Console.ReadLine()!;
                Console.Write("Stad/Ort: ");
                contact.Address.City = Console.ReadLine()!;
                contact.MemberID = id;
                //id++;

                _contactService.AddContact(contact);

                Console.WriteLine();
                Console.Write("Kontakten har sparats, vill du lägga till en till kontakt? (j/n): ");
                answer = Console.ReadLine()?.ToLower();

            } while (answer == "j");

        }
        catch { }
    }

    public void DeleteContactMenu()
    {
        Console.Clear();
        _contactService.ClearAllContacts();
        _contactService.ListContacts();

        /* ALTERNATIV TILL 'ListContacts()'
        Console.WriteLine("--- KONTAKTLISTA ---");
        Console.WriteLine("---------------------");
        foreach (var contact in _contactService.GetAllContacts())
        {
            Console.WriteLine($"Medlemsnr: {contact.MemberID}\t{contact.FirstName} {contact.LastName}   <{contact.Email}>");
        }
        */

        Console.Write("Ange medlemsnumret på den kontakt du önskar radera och tryck ENTER (Q = avsluta): ");
        var userInput = Console.ReadLine();
        
        if (int.TryParse(userInput, out int memberId))
        {

            if (_contactService.DeleteContact(memberId))
            {
                Console.WriteLine("Kontakten har tagits bort");
            }
            else
            {
                Console.WriteLine("Raderingen misslyckades");
            }

        }
        else if (userInput?.ToLower() == "q")
        {
            MainMenu();
        }
        else
        {
            Console.WriteLine("Felaktig inmatning...");
            Thread.Sleep(1500);
            DeleteContactMenu();
        }
        Console.ReadKey();

    }

    public void ShowOneContactMenu()
    {
        Console.Clear();
        _contactService.ClearAllContacts();
        _contactService.ListContacts();

        /* ALTERNATIV TILL 'ListContacts()'
        Console.WriteLine("--- KONTAKTLISTA ---");
        Console.WriteLine("---------------------");
        foreach (var contact in _contactService.GetAllContacts())
        {
            Console.WriteLine($"Medlemsnr: {contact.MemberID}\t{contact.FirstName} {contact.LastName}   <{contact.Email}>");
        }
        */

        Console.Write("Ange medlemsnummer för att se mer detaljer och tryck ENTER (Q = avsluta): ");
        var userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int memberId))
        {
            Console.Clear();
            var contact = _contactService.GetOneContact(memberId);
            Console.WriteLine($"Medlemsnr:\t[{contact.MemberID}]");
            Console.WriteLine($"Namn:\t\t{contact.FirstName} {contact.LastName}");
            Console.WriteLine($"E-post:\t\t< {contact.Email} >");
            Console.WriteLine($"Adress:\t\t{contact.Address?.FullAddress}"); // Varför behövs '?' på Address ????
            Console.WriteLine($"Unikt ID:\t{contact.Id}");
            Console.WriteLine($"Kontakt skapad:\t{contact.Created}");
            Console.WriteLine("---------------------");

        }
        else if (userInput?.ToLower() == "q")
        {
            MainMenu();
        }
        else
        {
            Console.WriteLine("Felaktig inmatning...");
            Thread.Sleep(1500);
            ShowOneContactMenu();
        }
        Console.ReadKey();
        
    }

}

