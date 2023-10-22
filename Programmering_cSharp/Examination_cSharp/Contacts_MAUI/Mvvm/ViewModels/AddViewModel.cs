using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts_MAUI.Mvvm.Models;
using Contacts_MAUI.Services;

namespace Contacts_MAUI.Mvvm.ViewModels;

public partial class AddViewModel : ObservableObject
{
    [ObservableProperty]
    ContactModel contact = new ContactModel();

    private ContactService contactService;

    public AddViewModel()
    {
        contactService = new ContactService();
    }

    // Lägger till ny kontakt i listan samt rensar gränssnittet 
    [RelayCommand]
    async Task Add()
    {
        contactService.AddToList(Contact);
        Contact = new ContactModel();
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}

