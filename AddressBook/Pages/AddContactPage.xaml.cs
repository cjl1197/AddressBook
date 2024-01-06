using Android.Content.Res;

namespace AddressBook.Pages;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}
	
	public async void Cancel_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
	public async void Add_Clicked(object sender, EventArgs e)
	{
		#if true
		await Navigation.PopModalAsync();
		#endif
	}
}
