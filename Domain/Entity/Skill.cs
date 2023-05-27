using Domain.Enums;

namespace Domain.Entity;

public sealed class Skill
{
    public Skill(Guid userId, SkillName name, float experienceYears)
    {
        UserId = userId;
        Name = name;
        ExperienceYears = experienceYears;
    }

    public int Id { get; set; }
    public Guid UserId { get; set; }
    public SkillName Name { get; set; }
    public float ExperienceYears { get; set; }
    public User User { get; set; }
}