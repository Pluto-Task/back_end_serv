namespace Domain.Entity;

public sealed class User
{
    public User(string email, string password, string name, string phone)
    {
        Email = email;
        Password = password;
        Name = name;
        Phone = phone;
        DateCreated = DateTime.Now;
        Rating = 0f;
        NumberOfEventsTookPart = 0;
        NumberOfEventsCreated = 0;
    }

    public User()
    {
    }

    public Guid Id { get; private set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public IEnumerable<Skill> Skills { get; set; }
    public DateTime DateCreated { get; set; }
    public float Rating { get; set; }
    public uint NumberOfEventsTookPart { get; set; }
    public uint NumberOfEventsCreated { get; set; }
}