namespace Domain.Entity
{
    public class EventSkills
    {
        public int Id { get; set; }

        public int SkillId { get; set; }

        public Guid UserEventId { get; set; }

        public uint Exp { get; set; }

        public UserEvent UserEvent { get; set; }

    }
}
