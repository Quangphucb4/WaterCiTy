using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IKhachHangMonRepository))]
    public class KhachHangMonRepository : Repository<KhachHangMonEntity>, IKhachHangMonRepository
    {
        public KhachHangMonRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

