using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.KhachHangMon;

namespace WaterCity.Contract.Service
{
    public interface IKhachHangMonService :
       Base.IGetable<KhachHangMonEntity, string>,
       Base.ICreateable<KhachHangMonModel, string>,
       Base.IUpdateable<KhachHangMonModel, string>,
       Base.IDeleteable<string, bool>
    {
    }
}
