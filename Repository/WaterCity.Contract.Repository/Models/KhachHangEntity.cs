
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("KhachHang")]
    public class KhachHangEntity : Entity
    {
       
       // [ForeignKey("NhaMay")]
        public string NhaMayId { get; set; }

        public string? NguonNuoc { get; set; }

        public string LoaiKhachHang { get; set; }

        public string TenKhachHang { get; set; }

        public string? TenThuongGoi { get; set; }

        public int? SoHo { get; set; }

        public string? Email { get; set; }

        public string? DienThoai { get; set; }

        public string? SoCmnd { get; set; }

        public string? NgayCapCmnd { get; set; }

        public string? NoiCapCmnd { get; set; }

        public string? MaSoThue { get; set; }

        public string? SoGcn { get; set; }

        public string? GhiChu { get; set; }

        public string? DoiTuong { get; set; }

        public int SoKhau { get; set; }

        public string? NguoiDaiDien { get; set; }
        public virtual ICollection<HopDongEntity>? HopDongs { get; set; }

    }
}
