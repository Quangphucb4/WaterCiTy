using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.CTHDMon;

namespace WaterCity.Contract.Service
{
    public interface ICTHDMonService :
       Base.IGetable<CTHDMonEntity, string>,
       Base.ICreateable<CTHDMonModel, string>,
       Base.IUpdateable<CTHDMonModel, string>,
       Base.IDeleteable<string, bool>
    {
    }
}
