using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IChiTietGiaRepository))]
    public class ChiTietGiaRepository : Repository<ChiTietGiaEntity>, IChiTietGiaRepository
    {
        public ChiTietGiaRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}