using Domain.Entity;

namespace Application.ResponseApiModel;

public record UserResponseApiModel(string Email, string Name, string Phone, IEnumerable<Skill> Skills,
    DateTime DateCreated, float Rating, uint NumberOfEventsTookPart, uint NumberOfEventsCreated);