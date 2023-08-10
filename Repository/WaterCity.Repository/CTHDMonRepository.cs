using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(ICTHDMonRepository))]
    public class CTHDMonRepository : Repository<CTHDMonEntity>, ICTHDMonRepository
    {
        public CTHDMonRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

