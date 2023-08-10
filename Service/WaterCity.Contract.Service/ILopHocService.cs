using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.LopHoc;

namespace WaterCity.Contract.Service
{
    public interface ILopHocService :
        Base.ICreateable<LopHocModel, string>,
        Base.IUpdateable<LopHocModel, string>,
        Base.IGetable<LopHocEntity, string>,
        Base.IDeleteable<string, bool>
    {

    }
}
