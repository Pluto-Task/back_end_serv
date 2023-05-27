using Domain.Enums;

namespace Domain.Entity;

public sealed class Skill
{
    public Skill(int id, int userId, SkillName name, float experienceYears)
    {
        Id = id;
        UserId = userId;
        Name = name;
        ExperienceYears = experienceYears;
    }

    public int Id { get; set; }
    public int UserId { get; set; }
    public SkillName Name { get; set; }
    public float ExperienceYears { get; set; }
    public User User { get; set; }
}