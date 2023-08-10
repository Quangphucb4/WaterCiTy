using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.HoaDonMon;

namespace WaterCity.Mapper
{
    public class HoaDonMonProfile : Profile
    {
        public HoaDonMonProfile()
        {
            CreateMap<HoaDonMonModel, HoaDonMonEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
