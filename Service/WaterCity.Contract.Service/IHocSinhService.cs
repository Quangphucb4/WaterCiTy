using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.HocSinh;

namespace WaterCity.Contract.Service
{
    public interface IHocSinhService :
        Base.ICreateable<HocSinhModel, string>,
        Base.IUpdateable<HocSinhModel, string>,
        Base.IGetable<HocSinhEntity, string>,
        Base.IDeleteable<string, bool>
    {

    }
}
