using Domain.Entity;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(User user, CancellationToken cancellationToken = default)
    {
        await _dbContext
            .Set<User>()
            .AddAsync(user, cancellationToken);
    }

    public async Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<User>().ToListAsync(cancellationToken);
    }

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken token = default)
    {
        return await _dbContext
            .Set<User>()
            .FirstOrDefaultAsync(x => x.Email == email, token);
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken = default)
    {
        return !await _dbContext
            .Set<User>()
            .AnyAsync(member => member.Email == email, cancellationToken);
    }

    public async Task<User?> FindByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _dbContext
            .Set<User>()
            .Include(x => x.Skills)
            .FirstOrDefaultAsync(x => x.Id == id, token);
    }
}