using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<TEntity>> GetAllByFilterAsync(Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default);

        void Delete(TEntity entity);
        void Update(TEntity entity);

        Task<IEnumerable<TEntity>> GetWithInclude(CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> GetWithInclude(Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default,
            params Expression<Func<TEntity, object>>[] includeProperties);

    }
}
