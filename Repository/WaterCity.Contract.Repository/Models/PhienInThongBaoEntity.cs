using WaterCity.Contract.Repository.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("PhienInThongBao")]
    public class PhienInThongBaoEntity : Entity
    {

        public string? TenPhien { get; set; }
        public DateTimeOffset? NgayTao { get; set; }
        public int? DaInXong { get; set; }
        public int? SoLuongHopDong { get; set; }
        public string? NhaMayId { get; set; }
        public string? NguoiDocId { get; set; }

        public virtual ICollection<HoaDonEntity>? HoaDons { get; set; }
    }
}
