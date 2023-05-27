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
        RatingSumm = 0;
        RatingCount = 0;
        NumberOfEventsTookPart = 0;
        NumberOfEventsCreated = 0;
    }

    public User()
    {
        DateCreated = DateTime.Now;
        NumberOfEventsTookPart = 0;
        NumberOfEventsCreated = 0;
    }

    public Guid Id { get; private set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public IEnumerable<Skill> Skills { get; set; }
    public DateTime DateCreated { get; set; }
    public uint RatingSumm { get; set; }
    public uint RatingCount { get; set; }
    public uint NumberOfEventsTookPart { get; set; }
    public uint NumberOfEventsCreated { get; set; }

    public IEnumerable<UserEvent> UserEvents { get; set; }
}