using Newtonsoft.Json;
namespace AddressBook.ViewModels;

public partial class PeopleVM : BaseVM
{
	public ObservableCollection<People> People { get; } = new();
	public Command GetPeopleCommand { get; }
	public Command AddContactCommand { get; }
	public Command PopModalCommand { get; }
	PeopleService peopleService;
	private string _fullName;
	public string FullName{
		get => _fullName;
		set => SetProperty(ref _fullName, value);
	}

	
	public PeopleVM(PeopleService peopleService)
	{
		Title = "People";
        this.peopleService = peopleService;
		GetPeopleCommand = new Command(async () => await GetContactsAsync());
		AddContactCommand = new Command(async () => await AddContactAsync());
		PopModalCommand = new Command (async () => PopModalAsync());
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
	
	public async Task AddContactAsync()
	{
		string firstName = "";
		string lastName = "";
		for (int i = 0; i < _fullName.Length; i++)
		{
			if(_fullName[i] == ' ')
			{
				firstName = _fullName.Substring(0, i);
				lastName = _fullName.Substring(i + 1);
			}
		}

		bool added = false;
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;
			
			added = await peopleService.AddContact(firstName, lastName);

		}
		catch (Exception ex)
		{
			Debug.WriteLine($"Unable to add contact: {ex.Message}");
			await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
		}
		finally
		{
			IsBusy = false;
		}
		if (added)
		{
			Debug.WriteLine("Successful");
			PopModalCommand.Execute(null);
		}
	}
	
	public async void PopModalAsync()
	{
			await AppShell.Current.Navigation.PopModalAsync();
	}

    public static async Task<People> GetContact(int userId)
	{
			HttpClient httpClient = new HttpClient();
			string json = await httpClient.GetStringAsync($"http://10.0.2.2:8080/users/{userId}");
			return JsonConvert.DeserializeObject<People>(json);

    }

	
	
		 
}
