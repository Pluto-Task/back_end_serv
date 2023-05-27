namespace Application.RequestApiModel;

public sealed record UserEventRequestApiModel(string Title, DateTime StartDate,
    DateTime EndDate, IDictionary<string,float> Skills, string Address, string Build,
    string PhoneNumber, string Coordinates, string Email);

