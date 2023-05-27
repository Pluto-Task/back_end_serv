namespace Domain.Entity
{
    public class UserEvent
    {
        public UserEvent(string title, string description ,DateTime startDate, DateTime endDate, uint maxPeople, uint currentPeople, string address, string build, string phoneNumber, string coordinates, string email, Guid createdBy)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            CreatedDate = DateTime.Now;
            MaxPeople = maxPeople;
            CurrentPeople  = currentPeople;
            Address = address;
            Build = build;
            PhoneNumber = phoneNumber;
            Email = email;
            Coordinates = coordinates;
            CreatedBy = createdBy;
            IsClosed = false;
        }

        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set;}

        public string Address { get; set; }
        public string Build { get; set; }

        public uint MaxPeople { get; set; }

        public uint CurrentPeople {get; set; }

        public string PhoneNumber { get; set; }

        public string Coordinates {get; set; }

        public string Email { get; set; }

        public Guid CreatedBy { get; set; }

        public IEnumerable<User> Users { get; set; }
        public IEnumerable<EventSkills> EventSkills { get; set; }

        public bool IsClosed { get; set; }
    }
}
