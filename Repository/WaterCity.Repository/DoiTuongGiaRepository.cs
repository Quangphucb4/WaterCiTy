using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IDoiTuongGiaRepository))]
    public class DoiTuongGiaRepository : Repository<DoiTuongGiaEntity>, IDoiTuongGiaRepository
    {
        public DoiTuongGiaRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

