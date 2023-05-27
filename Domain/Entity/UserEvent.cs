namespace Domain.Entity
{
    public class UserEvent
    {
        public UserEvent(string title, DateTime startDate, DateTime endDate, IDictionary<string,float> skills, string address, string build, string phoneNumber, string coordinates, string email, Guid createdBy)
        {
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            CreatedDate = DateTime.Now;
            Skills = skills;
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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set;}

        public IDictionary<string, float> Skills { get; set; }

        public string Address { get; set; }
        public string Build { get; set; }

        public string PhoneNumber { get; set; }

        public string Coordinates {get; set; }

        public string Email { get; set; }

        public Guid CreatedBy { get; set; }

        public IEnumerable<User> Users { get; set; }

        public bool IsClosed { get; set; }
    }
}
