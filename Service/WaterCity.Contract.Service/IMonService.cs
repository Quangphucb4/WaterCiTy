using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.Mon;

namespace WaterCity.Contract.Service
{
    public interface IMonService :
       Base.IGetable<MonEntity, string>,
       Base.ICreateable<MonModel, string>,
       Base.IUpdateable<MonModel, string>,
       Base.IDeleteable<string, bool>
    {
    }
}
