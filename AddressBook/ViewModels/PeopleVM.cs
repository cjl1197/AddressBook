namespace AddressBook.ViewModels;

public partial class PeopleVM : BaseVM
{
	public ObservableCollection<People> People { get; } = new();
	public Command GetPeopleCommand { get; }
	PeopleService peopleService;
	
	public PeopleVM(PeopleService peopleService)
	{
		Title = "People";
		this.peopleService = peopleService;
		GetPeopleCommand = new Command(async () => await GetContactsAsync());
;
	}
	
	public async Task GetContactsAsync()
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;
			
			var peoples = await peopleService.GetContacts();

			if (People.Count != 0)
				People.Clear();

			foreach (var people in peoples)
				People.Add(people);
			
		}
		catch (Exception ex)
		{
			Debug.WriteLine($"Unable to get people: {ex.Message}");
			await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
		}
		finally
		{
			IsBusy = false;
		}
	}

    public static async Task<People> GetContact(int userId)
	{
			HttpClient httpClient = new HttpClient();
			string json = await httpClient.GetStringAsync($"http://10.0.2.2:8080/users/{userId}");
			return JsonConvert.DeserializeObject<People>(json);

    }

	
	
		 
}
