using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IHoaDonMonRepository))]
    public class HoaDonMonRepository : Repository<HoaDonMonEntity>, IHoaDonMonRepository
    {
        public HoaDonMonRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

