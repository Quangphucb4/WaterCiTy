using AutoMapper;
using WaterCity.Contract.Repository.Models;
using WaterCity.Core.Models.KhachHangMon;

namespace WaterCity.Mapper
{
    public class KhachHangMonProfile : Profile
    {
        public KhachHangMonProfile()
        {
            CreateMap<KhachHangMonModel, KhachHangMonEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
