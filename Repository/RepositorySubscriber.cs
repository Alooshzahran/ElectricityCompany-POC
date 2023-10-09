using Entity;
using Entity.Repository;

namespace Repository
{
    public class RepositorySubscriber : Repository<Subscriber>,IRepositorySubscriber
    {
        public RepositorySubscriber(MyDbContext dbContext): base(dbContext)
        {
        }
    }
}
