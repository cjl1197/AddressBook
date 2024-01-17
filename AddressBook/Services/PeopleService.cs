using System.Dynamic;
using System.Text;
using System.Text.Json;
namespace AddressBook.Services;

public class PeopleService
{
    List<People> people = new();
    HttpClient httpClient;

    public PeopleService()
    {
        this.httpClient = new HttpClient();
    }
    
    public async Task<List<People>> GetContacts()
    {
        var response = await httpClient.GetAsync("http://10.0.2.2:8080/users");

        if (response.IsSuccessStatusCode)
        {
            people = await response.Content.ReadFromJsonAsync<List<People>>();
        }
        return people;
    }
    
    public async Task<bool> AddContact(string first_name, string last_name)
    {
        
       People people = new()
       {
        first_name = first_name,
        last_name = last_name
       };
       

       string peopleJson = JsonSerializer.Serialize<People>(people);
        

        var content = new StringContent(peopleJson, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("http://10.0.2.2:8080/users",content);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        else
            return false;
        
        
        return true;
    }
}
