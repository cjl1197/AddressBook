namespace AddressBook;

public partial class MainPage : ContentPage
{

	public MainPage(PeopleVM peopleVM)
	{
		InitializeComponent();
		peopleVM.GetPeopleCommand.Execute(null);
		BindingContext = peopleVM;
		
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

