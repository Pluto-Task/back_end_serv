namespace Application.RequestApiModel;

public record FilterRequestApiModel(string City, int MaxPeople, IEnumerable<int> Skills);

