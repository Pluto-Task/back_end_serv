using Domain.Entity;

namespace Application.ResponseApiModel;

public record UserResponseApiModel(string Email, string Name, string Phone, IEnumerable<SkillResponseApiModel> Skills,
    DateTime DateCreated, float Rating, uint NumberOfEventsTookPart, uint NumberOfEventsCreated);