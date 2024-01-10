using System.ComponentModel;
using AddressBook.View;
using AddressBook.Models;
using Newtonsoft.Json;
namespace AddressBook.ViewModel;

public class PeopleVM
{
    public List<People> people { get; set;}

    public static async Task<List<People>> GetContacts()
	{
			HttpClient httpClient = new HttpClient();
			string json = await httpClient.GetStringAsync("http://10.0.2.2:8080/users");
			return JsonConvert.DeserializeObject<List<People>>(json);

    }


	
		 
}
