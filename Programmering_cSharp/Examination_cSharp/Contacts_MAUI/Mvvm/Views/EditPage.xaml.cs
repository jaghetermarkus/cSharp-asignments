using Contacts_MAUI.Mvvm.Models;
using Contacts_MAUI.Mvvm.ViewModels;
using Contacts_MAUI.Services;

namespace Contacts_MAUI.Mvvm.Views;

[QueryProperty("ContactID", "ContactId")]
public partial class EditPage : ContentPage
{
    // Tar emot endast Contact.Id från förra sidan, för att sedan söka fram hela kontakten via ContactService
    private ContactModel contact;
    public string ContactID
    {
        set
        {
            contact = ContactService.GetOneContact(value);// ContactId som skickats med från föregående sida skickas vidare för att hitta specifik kontakt och tilldela 'contact'. 
            OnPropertyChanged();

            if (BindingContext is EditViewModel viewModel)
            {
                viewModel.Contact = contact;
            }

        }
    }

    public EditPage(EditViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    /* OnNavigatedTo
    protected override void OnNavigatedTo(string contactId)
    {
        base.OnNavigatedTo(contactId);



        if (parameters.TryGetValue("ContactId", out var contactIdString) && Guid.TryParse(contactIdString, out var contactId))
        {
            ContactModel Contact = ContactService.GetOneContact(contactId);
        }
    }
    */
}
