namespace AddressBook.View;

public partial class AddContactPage : ContentPage
{

	public AddContactPage()
	{
		InitializeComponent();
		Debug.WriteLine("page loaded");
		PeopleService peopleService = new PeopleService();
		BindingContext = new PeopleVM(peopleService);
		
	}
	
	public async void Cancel_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
	
}
