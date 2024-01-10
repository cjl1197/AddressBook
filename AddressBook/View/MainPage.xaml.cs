using AddressBook.Models;
using AddressBook.View;
using AddressBook.ViewModels;

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
		
	private async void OnTapped(object sender, EventArgs e)
	{
		// placeholder for navigating to a single persons info. needs to be completed
		var user = (StackLayout)sender;
		if (user.BindingContext is People userTapped)
		{
			int userId = userTapped.id;
			await Navigation.PushAsync(new ContactInfoPage(userId)); 
		}
	}
	
	
	private async void AddContact_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new AddContactPage()); 

	}
}

