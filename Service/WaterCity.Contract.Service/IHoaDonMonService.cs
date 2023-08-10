using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.HoaDonMon;

namespace WaterCity.Contract.Service
{
    public interface IHoaDonMonService :
       Base.IGetable<HoaDonMonEntity, string>,
       Base.ICreateable<HoaDonMonModel, string>,
       Base.IUpdateable<HoaDonMonModel, string>,
       Base.IDeleteable<string, bool>
    {
    }
}
