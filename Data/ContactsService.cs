namespace BlazorApp.Data;

public class ContactsService
{
    private List<Contact> AllContacts = new List<Contact>(){
        new Contact("ismael", "ismael@gmail.com"),
        new Contact("dassi", "dassi@gmail.com"),
        new Contact("messa", "messa@gmail.com"),
        new Contact("bradley", "bradleay@gmail.com"),
        new Contact("king", "king@gmail.com"),
        new Contact("Simon", "simon@gmail.com"),
        new Contact("Erick", "erick@gmail.com"),
        new Contact("Fred", "fred@gmail.com"),
        new Contact("JohnSon", "johnson@gmail.com")
    };
    
    public void AddContact(Contact cnt)
    {
        AllContacts.Add(cnt);
    }

    public void DeleteContact(Contact cnt)
    {

    }

    public void UpdateContact(Contact cnt)
    {

    }

    public Task<List<Contact>> GetAllContacts() {
        return Task.FromResult(AllContacts);
    }
}