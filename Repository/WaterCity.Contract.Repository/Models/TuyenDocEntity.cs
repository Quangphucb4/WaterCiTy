using WaterCity.Contract.Repository.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("TuyenDoc")]
    public class TuyenDocEntity : Entity
    {
      
        public string? NhaMayId { get; set; }
        public string NguoiQuanLyId { get; set; }
       // public string MaTuyen { get; set; }
        public string TenTuyen { get; set; }
        public string NguoiThuTienId { get; set; }
        public string? SDTNguoiThu { get; set; }
        public string? DiaChiThu { get; set; }
        public DateTimeOffset? ThoiGianThu { get; set; }
        public string? SDTHoaDon { get; set; }
        public string? SDTSuaChua { get; set; }
        public string? KyGhiChiSoId { get; set; }
        public string? NhanVienXem { get; set; }
        public string? NhanVienSua { get; set; }
        /*   public virtual ICollection<NguoiDungEntity>? NhanVienXemIds { get; set; }
           public virtual ICollection<NguoiDungEntity>? NhanVienSuaIds { get; set; }*/
        public DateTimeOffset? NgayGhiCSTu { get; set; }
        public DateTimeOffset? NgayGhiCSDen { get; set; }

        [ForeignKey("KhuVuc")]
        public string KhuVucId { get; set; }
        public virtual KhuVucEntity KhuVuc { get; set; }
        public virtual ICollection<HopDongEntity>? HopDongs { get; set; }
        public virtual ICollection<SoDocChiSoEntity>? SoDocChiSos { get; set; }
    }
}
