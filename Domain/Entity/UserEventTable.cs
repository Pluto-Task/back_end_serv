namespace Domain.Entity
{
    public class UserEventTable
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid UserEventId { get; set; }

        public UserEvent UserEvent { get; set; }

        public bool IsConfirmed { get; set; }
    }
}
