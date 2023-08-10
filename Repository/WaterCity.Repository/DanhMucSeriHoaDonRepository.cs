using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IDanhMucSeriHoaDonRepository))]
    public class DanhMucSeriHoaDonRepository : Repository<DanhMucSeriHoaDonEntity>, IDanhMucSeriHoaDonRepository
    {
        public DanhMucSeriHoaDonRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

