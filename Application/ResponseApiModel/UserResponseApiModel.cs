using Domain.Entity;

namespace Application.ResponseApiModel;

public record UserResponseApiModel(string Email, string Name, string Phone, IEnumerable<UserSkillResponseApiModel> Skills,
    DateTime DateCreated, uint NumberOfEventsTookPart, uint NumberOfEventsCreated);