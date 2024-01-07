using AddressBook.View;

namespace AddressBook;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));

	}

}
