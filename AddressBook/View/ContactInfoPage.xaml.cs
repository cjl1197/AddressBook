using AddressBook.ViewModels;
using AddressBook.Models;
namespace AddressBook.View;
public partial class ContactInfoPage : ContentPage
{
	public ContactInfoPage(int userId)
	{
		InitializeComponent();
		LoadContact(userId);
	}

	private async void LoadContact(int userId)
	{
		People user = await PeopleVM.GetContact(userId);
		
		BindingContext = user;
	}
}