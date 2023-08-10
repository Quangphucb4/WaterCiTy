using System.ComponentModel.DataAnnotations.Schema;
using WaterCity.Core.EnumCore;

namespace WaterCity.Contract.Repository.Models
{
    [Table("DanhMucThongBao")]

    public class DanhMucThongBaoEntity : Entity
    {
        public HinhThucThongBao HinhThuc { get; set; }
        public string NguoiGuiId { get; set; }
        public DateTimeOffset ThoiGian { get; set; }
        public string TenLanGui { get; set; }
        
        public ICollection<ThongBaoEntity> ThongBaos { get; set; }
    }
}
