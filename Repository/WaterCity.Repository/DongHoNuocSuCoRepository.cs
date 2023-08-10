using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IDongHoNuocSuCoRepository))]
    public class DongHoNuocSuCoRepository : Repository<DongHoNuocSuCoEntity>, IDongHoNuocSuCoRepository
    {
        public DongHoNuocSuCoRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

