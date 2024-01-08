using AddressBook.View;

namespace AddressBook;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		
		
		List<Contact> contacts = new List<Contact>()
		{
			new Contact { Name="John Smith", Email="JohnSmith@mail.com"},
			new Contact { Name="Jane Doe", Email="JaneDoe@mail.com"},
			new Contact { Name="Mom"},
			new Contact { Name="Dad", Email="dad@mail.com"}
		 
		};
		
		listContacts.ItemsSource = contacts;
	}
	
	
	private async void AddContact_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new AddContactPage()); 

	}
}

