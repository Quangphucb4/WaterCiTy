using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IChucNangRepository))]
    public class ChucNangRepository : Repository<ChucNangEntity>, IChucNangRepository
    {
        public ChucNangRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}