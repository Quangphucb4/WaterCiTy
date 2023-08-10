using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IDanhMucThongBaoRepository))]
    public class DanhMucThongBaoRepository : Repository<DanhMucThongBaoEntity>, IDanhMucThongBaoRepository
    {
        public DanhMucThongBaoRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

