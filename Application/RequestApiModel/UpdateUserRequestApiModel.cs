namespace Application.RequestApiModel;

public record UpdateUserRequestApiModel(string Name, string Phone, IEnumerable<SkillRequestApiModel> Skills);