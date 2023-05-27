namespace Application.RequestApiModel;

public sealed record UserEventRequestApiModel(string Title, string Description, DateTime StartDate,
    DateTime EndDate, uint MaxPeople, uint CurrentPeople, IEnumerable<EventSkillsRequestApiModel> Skills, string Address, string Build,
    string PhoneNumber, string Coordinates, string Email);