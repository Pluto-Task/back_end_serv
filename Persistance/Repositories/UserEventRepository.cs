using Domain.Entity;

namespace Persistence.Repositories
{
    public class UserEventRepository : GenericRepository<UserEvent>
    {
        private readonly ApplicationDbContext _dbContext;
        public UserEventRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}