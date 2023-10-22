using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts_MAUI.Mvvm.Models;

namespace Contacts_MAUI.Mvvm.ViewModels;

public partial class EditViewModel : ObservableObject
{
    [ObservableProperty]
    ContactModel contact = new ContactModel();

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    // Spara-knapp, skickar uppdaterade kontaktuppgifter vidare till MainViewModel, för att sen anropa ContactService och uppdatera listan
    [RelayCommand]
    async Task SaveChanges(ContactModel updatedContact)
    {
        await Shell.Current.GoToAsync("..",
            new Dictionary<string, object>
            {
                { "updatedContact", updatedContact }
            });
    }

}

