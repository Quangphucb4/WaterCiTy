using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IMonRepository))]
    public class MonRepository : Repository<MonEntity>, IMonRepository
    {
        public MonRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

