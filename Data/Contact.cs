namespace BlazorApp.Data;

public class Contact
{
    public Contact(string name, string email)
    {
        Date = new DateTime();
        Name = name;
        Email = email;
    }

    public DateTime Date {get; set;}
    public string Name {get; set;}
    public int Number {get; set;}
    public String? Email {get; set;}
}