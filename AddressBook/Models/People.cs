namespace AddressBook.Models;

public class People
{
    public int id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string phone_number { get; set; }
	public string? email { get; set; }
    public string street_address { get; set; } 
    public string state { get; set; }
    public string zip_code { get; set; }
    public string full_name { get { return first_name + " " + last_name; }}
    public string full_address { get { return street_address + " " + state + " " + zip_code; }}

}
