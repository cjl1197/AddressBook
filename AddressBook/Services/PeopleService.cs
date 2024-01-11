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
}
