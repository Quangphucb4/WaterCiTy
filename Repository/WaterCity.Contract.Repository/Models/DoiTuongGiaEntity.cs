using System.ComponentModel.DataAnnotations.Schema;
using WaterCity.Core.EnumCore;

namespace WaterCity.Contract.Repository.Models
{


    [Table("DoiTuongGia")]
    public class DoiTuongGiaEntity : Entity
    {

        public DateTimeOffset NgayBatDau { get; set; }
        public DateTimeOffset? NgayKetThuc { get; set; }

        public decimal VAT { get; set; }
        public CachTinhBVMT BVMT { get; set; }
        public decimal PhiBvmt { get; set; }

        public CachTinhDTGia DTTinhGia { get; set; }

        public KieuTinhGia KieuTinh { get; set; }


        public bool CoToiThieu { get; set; }
        public decimal? TinhTu { get; set; }
        public decimal? ToiThieu { get; set; }

        [ForeignKey("PhiDuyTri")]
        public string? PhiDuyTriId { get; set; }
        public virtual PhiDuyTriEntity? PhiDuyTri { get; set; }

        [ForeignKey("DanhSachDoiTuongGia")]
        public string? DanhSachDoiTuongGiaId { get; set; }
        public virtual DanhSachDoiTuongGiaEntity? DanhSachDoiTuongGia { get; set; }
        public virtual ICollection<ChiTietGiaEntity>? ChiTietGias { get; set; }
        public virtual ICollection<HopDongEntity>? HopDongs { get; set; }
    }
}
