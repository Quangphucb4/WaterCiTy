using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IDongHoNuocRepository))]
    public class DongHoNuocRepository : Repository<DongHoNuocEntity>, IDongHoNuocRepository
    {
        public DongHoNuocRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

