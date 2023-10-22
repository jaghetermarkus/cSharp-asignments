using Contacts_MAUI.Mvvm.ViewModels;

namespace Contacts_MAUI.Mvvm.Views;

public partial class AddPage : ContentPage
{
	public AddPage(AddViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
