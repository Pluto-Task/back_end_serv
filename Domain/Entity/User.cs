namespace Domain.Entity;

public sealed class User
{
    public User(Guid id, string email, string password, string name, string phone, IEnumerable<Skill> skills,
        float rating, int numberOfEventsTookPart)
    {
        Id = id;
        Email = email;
        Password = password;
        Name = name;
        Phone = phone;
        Skills = skills;
        DateCreated = DateTime.Now;
        Rating = rating;
        NumberOfEventsTookPart = numberOfEventsTookPart;
    }

    public Guid Id { get; private set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public IEnumerable<Skill> Skills { get; set; }
    public DateTime DateCreated { get; set; }
    public float Rating { get; set; }
    public int NumberOfEventsTookPart { get; set; }
}