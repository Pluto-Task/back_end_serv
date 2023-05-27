namespace Application.RequestApiModel;

public record UserRatingRequestApiModel(Guid userId, uint rating);