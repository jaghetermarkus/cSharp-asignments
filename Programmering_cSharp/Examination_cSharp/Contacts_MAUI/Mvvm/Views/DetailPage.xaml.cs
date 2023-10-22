using Contacts_MAUI.Mvvm.Models;
using Contacts_MAUI.Mvvm.ViewModels;

namespace Contacts_MAUI.Mvvm.Views;

[QueryProperty(nameof(Contact), "Contact")] // Tar emot hel kontakt för föregående sida och tilldelar uppgifter i Contact nedan.
public partial class DetailPage : ContentPage
{
	
	private ContactModel contact;
	public ContactModel Contact
	{
		get => contact;
		set
		{
			contact = value;
			OnPropertyChanged();
			if (BindingContext is DetailViewModel viewModel)
			{
				viewModel.Contact = Contact;
			}
		}
	}

	public DetailPage(DetailViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
