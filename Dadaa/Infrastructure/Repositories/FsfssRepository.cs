using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class FsfssRepository : RepositoryBase<Fsfss>, IFsfssRepository
    {
        public FsfssRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
