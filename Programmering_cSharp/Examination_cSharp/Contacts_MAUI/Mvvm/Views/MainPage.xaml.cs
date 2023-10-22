using Contacts_MAUI.Mvvm.Models;
using Contacts_MAUI.Mvvm.ViewModels;
using Contacts_MAUI.Services;

namespace Contacts_MAUI.Mvvm.Views;

[QueryProperty(nameof(UpdatedContact), "updatedContact")]
public partial class MainPage : ContentPage
{
    private ContactService contactService;
    private ContactModel updatedContact;

    public ContactModel UpdatedContact
    {
        set
        {
            if (value != null)
            {
                // Tilldela värdet från föregående sida till nedan variabel och skicka vidare för uppdatering av listan
                updatedContact = value;
                contactService.SaveUpdatedContact(updatedContact);
                updatedContact = null;
            }
        }
    }


    public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        contactService = new ContactService();
	}
}
