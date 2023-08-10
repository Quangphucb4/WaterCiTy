using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("DanhSachHoDan")]

    public class DanhSachHoDanEntity : Entity
    {

        public string TenKhachHang { get; set; }

        public string? TenThuongGoi { get; set; }

        public int? SoHo { get; set; }

        public string? Email { get; set; }

        public string? DienThoai { get; set; }

        public int SoKhau { get; set; }

        public string? GhiChu { get; set; }


        [ForeignKey("KhuVuc")]
        public string KhuVucId { get; set; }
        public virtual KhuVucEntity KhuVuc { get; set; }
    }
}
