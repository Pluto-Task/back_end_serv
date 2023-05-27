using Domain.Entity;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email, CancellationToken token = default);

    Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default);

    Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken = default);

    Task Add(User user, CancellationToken cancellationToken = default);

    Task<User?> FindByIdAsync(Guid id, CancellationToken token = default);
}