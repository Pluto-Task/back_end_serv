namespace Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync();
    Task CommitAsync();
    void Rollback();
}