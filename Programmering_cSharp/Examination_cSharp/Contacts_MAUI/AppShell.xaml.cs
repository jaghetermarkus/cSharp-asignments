using Contacts_MAUI.Mvvm.Views;

namespace Contacts_MAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddPage), typeof(AddPage));
        Routing.RegisterRoute(nameof(EditPage), typeof(EditPage));
        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));

    }
}

