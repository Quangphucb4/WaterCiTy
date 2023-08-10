using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.LoaiMon;

namespace WaterCity.Mapper
{
    public class LoaiMonProfile : Profile
    {
        public LoaiMonProfile()
        {
            CreateMap<LoaiMonModel, LoaiMonEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
