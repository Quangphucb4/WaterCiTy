using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IChiTietHoaDonRepository))]
    public class ChiTietHoaDonRepository : Repository<ChiTietHoaDonEntity>, IChiTietHoaDonRepository
    {
        public ChiTietHoaDonRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

