using Contact.Maui.Views;

namespace Contact.Maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ContactPage), typeof(ContactPage));
        Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
        Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
    }
}

