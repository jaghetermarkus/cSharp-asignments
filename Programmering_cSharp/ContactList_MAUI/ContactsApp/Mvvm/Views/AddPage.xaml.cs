using ContactsApp.Mvvm.ViewModels;
using Microsoft.Maui.Controls;

namespace ContactsApp.Mvvm.Views;

public partial class AddPage : ContentPage
{
    public AddPage(AddViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}