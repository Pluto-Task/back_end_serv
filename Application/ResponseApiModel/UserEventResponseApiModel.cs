namespace Application.ResponseApiModel;

public record UserEventResponseApiModel(Guid Id,string Title, string Description, DateTime StartDate, DateTime EndDate,
    IEnumerable<EventSkillsResponseApiModel> Skills, string Phone, string Email, string Address, string Build,
    string Coordinates);



