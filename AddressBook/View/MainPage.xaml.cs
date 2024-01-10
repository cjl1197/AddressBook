using AddressBook.View;
using AddressBook.ViewModel;

namespace AddressBook;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		
		LoadContacts();
	}

	private async void LoadContacts()
	{
		listContacts.ItemsSource = await PeopleVM.GetContacts();
	}
		

	
	
	private async void AddContact_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new AddContactPage()); 

	}
}

