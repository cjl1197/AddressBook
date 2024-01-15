namespace AddressBook.View;

public partial class AddContactPage : ContentPage
{

	public AddContactPage()
	{
		InitializeComponent();
		//BindingContext = peopleVM;
	}
	
	public async void Cancel_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
	public async void Add_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
}
