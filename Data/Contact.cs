using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Data;

public class Contact
{
    public Contact(string name, string email)
    {
        Date = new DateTime();
        Name = name;
        Email = email;
    }

    [Required]
    public DateTime Date {get; set;}
    
    [Required]
    public string Name {get; set;}
    
    [Required]
    public int Number {get; set;}
    
    [Required]
    public String? Email {get; set;}
}