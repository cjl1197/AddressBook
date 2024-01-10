namespace AddressBook.Models;

public class People
{
    public int id { get; set; }
    public string first_name {get; set;}
    public string last_name {get; set;}
	public string? email {get; set;}
    public string full_name { get { return first_name + " " + last_name; }}

}
