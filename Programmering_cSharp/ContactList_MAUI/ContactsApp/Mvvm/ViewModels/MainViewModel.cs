using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactsApp.Mvvm.Models;
using ContactsApp.Mvvm.Views;
using ContactsApp.Services;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Controls;

namespace ContactsApp.Mvvm.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>();

    private ContactService contactService;

    public MainViewModel()
    {
        contactService = new ContactService();
        UpdateContacts(); // Uppdaterar kontakterna vid start samt när ContactsUpdated triggas
        ContactService.ContactsUpdated += UpdateContacts;
    }

    // Synkar List<> i ContactService med ObservableCollection<>.
    void UpdateContacts()
    {
        Contacts.Clear();
        // Foreach för att kringgå problematiken med 2 olika list-typer
        foreach (var contact in contactService.GetContacts())
            Contacts.Add(contact);
    }

    [RelayCommand]
    async Task GoToAdd()
    {
        await Shell.Current.GoToAsync(nameof(AddPage));
    }

    /* ALTERNATIV GoToEdit
    [RelayCommand]
    async Task GoToEdit(Guid contactId)
    {
        await Shell.Current.GoToAsync(nameof(EditPage),
            new Dictionary<string, string>
            {
                { "ContactId", contactId.ToString() }
            });
    }
    */

    // Skickar endast Contact.Id vidare, för att sedan söka fram hela kontakten på mottagarsidan istället. 
    [RelayCommand]
    async Task GoToEdit(Guid contactId)
    {
        await Shell.Current.GoToAsync($"{nameof(EditPage)}?ContactId={contactId}");
    }

    // Skickar en hel kontakt vidare till nästa sida för att visa detaljer
    [RelayCommand]
    async Task GoToDetail(ContactModel contact)
    {
        await Shell.Current.GoToAsync(nameof(DetailPage),
            new Dictionary<string, object>
            {
                { "Contact", contact }
            });
    }

    // Delete-knapp, skickar kontakten från MainPage vidare till ContactService för uppdatering av listan
    [RelayCommand]
    void DeleteContact(ContactModel contact)
    {
        contactService.DeleteContact(contact);
        // UpdateContacts(); Behövs inte då det görs i DeleteContact?
    }

}