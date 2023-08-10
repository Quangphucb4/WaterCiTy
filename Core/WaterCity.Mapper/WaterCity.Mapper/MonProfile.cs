using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.Mon;

namespace WaterCity.Mapper
{
    public class MonProfile : Profile
    {
        public MonProfile()
        {
            CreateMap<MonModel, MonEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
