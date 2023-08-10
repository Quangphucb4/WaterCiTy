using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IHangSanXuatRepository))]
    public class HangSanXuatRepository : Repository<HangSanXuatEntity>, IHangSanXuatRepository
    {
        public HangSanXuatRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

