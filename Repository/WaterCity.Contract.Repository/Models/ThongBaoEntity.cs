using System.ComponentModel.DataAnnotations.Schema;
using WaterCity.Core.EnumCore;

namespace WaterCity.Contract.Repository.Models
{
    [Table("ThongBao")]

    public class ThongBaoEntity : Entity
    {
        public KieuGui KieuGuiTB { get; set; }
        public TrangThaiThanhToan TrangThaiTT { get; set; }
        public TinhTrangThongBao TinhTrang { get; set; }
        public TrangThaiThongBao TrangThaiTB { get; set; }

        [ForeignKey("DanhMucThongBao")]
        public string DanhMucThongBaoId { get; set; }
        public virtual DanhMucThongBaoEntity DanhMucThongBao { get; set; }

        [ForeignKey("HoaDon")]
        public string HoaDonId { get; set; }
        public virtual HoaDonEntity HoaDon { get; set; }

    }
}
