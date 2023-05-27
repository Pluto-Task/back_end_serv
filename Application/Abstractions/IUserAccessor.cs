namespace Application.Abstractions;

public interface IUserAccessor
{
    Guid GetCurrentUserId();
}