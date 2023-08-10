using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.CTHDMon;

namespace WaterCity.Mapper
{
    public class CTHDMonProfile : Profile
    {
        public CTHDMonProfile()
        {
            CreateMap<CTHDMonModel, CTHDMonEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
