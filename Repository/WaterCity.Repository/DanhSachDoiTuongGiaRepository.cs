using Invedia.DI.Attributes;
using WaterCity.Contract.Repository.Infrastructure;
using WaterCity.Contract.Repository.Interface;
using WaterCity.Contract.Repository.Models;
using WaterCity.Repository.Infrastructure;

namespace WaterCity.Repository
{
    [ScopedDependency(ServiceType = typeof(IDanhSachDoiTuongGiaRepository))]
    public class DanhSachDoiTuongGiaRepository : Repository<DanhSachDoiTuongGiaEntity>, IDanhSachDoiTuongGiaRepository
    {
        public DanhSachDoiTuongGiaRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}

