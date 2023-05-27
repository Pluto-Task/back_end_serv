namespace Domain.Entity;

public sealed class User 
{
    public User(string email, string password, string name)
    {
        Id = Guid.NewGuid();
        Email = email;
        Password = password;
        Accounts = new List<Account>();
        Name=name;
    }
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IEnumerable<Account> Accounts { get; set; }
}