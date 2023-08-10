using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IChucVuRepository))]
    public class ChucVuRepository : Repository<ChucVuEntity>, IChucVuRepository
    {
        public ChucVuRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

