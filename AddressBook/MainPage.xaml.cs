using AddressBook.Pages;
using System;

namespace AddressBook;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		
		List<string> contacts = new List<string>()
		{
			"John Smith",
			"Jane Doe",
			"Dad",
			"Mom"
		};
		
		listContacts.ItemsSource = contacts;

	}
	

	private async void AddContact_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new AddContactPage());
	}
}

