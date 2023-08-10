using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.LoaiMon;

namespace WaterCity.Contract.Service
{
    public interface ILoaiMonService :
       Base.IGetable<LoaiMonEntity, string>,
       Base.ICreateable<LoaiMonModel, string>,
       Base.IUpdateable<LoaiMonModel, string>,
       Base.IDeleteable<string, bool>
    {
    }
}
