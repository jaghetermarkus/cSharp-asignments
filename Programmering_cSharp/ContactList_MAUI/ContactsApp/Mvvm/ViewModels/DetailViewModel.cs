using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactsApp.Mvvm.Models;
using Microsoft.Maui.Controls;

namespace ContactsApp.Mvvm.ViewModels;

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