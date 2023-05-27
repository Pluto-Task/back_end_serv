using Domain.Entity;

namespace Application.RequestApiModel;

public sealed record RegisterRequestApiModel(string Email, string Password, string Name, string Phone,
    IEnumerable<SkillRequestApiModel> Skills);