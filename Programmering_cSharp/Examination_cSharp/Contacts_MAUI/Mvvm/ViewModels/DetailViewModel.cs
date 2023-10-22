using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts_MAUI.Mvvm.Models;

namespace Contacts_MAUI.Mvvm.ViewModels;

public partial class DetailViewModel : ObservableObject
{

    [ObservableProperty]
    ContactModel contact = new ContactModel();

    [RelayCommand]
    async Task GoBack()
    {
        //await Shell.Current.GoToAsync("..");
        await Shell.Current.Navigation.PopAsync();
    }
}

