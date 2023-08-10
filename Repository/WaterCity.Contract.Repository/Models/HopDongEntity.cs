
using System.ComponentModel.DataAnnotations.Schema;
using WaterCity.Core.EnumCore;

namespace WaterCity.Contract.Repository.Models
{
    [Table("HopDong")]
    public class HopDongEntity : Entity
    {

        [ForeignKey("KhachHang")]
        public string? KhachHangId { get; set; }


        //[ForeignKey("NhaMay")]
        public string? NhaMayId { get; set; }

        public string? KhuVucThanhToan { get; set; }

        public string? PhuongThucThanhToanId { get; set; }

        [ForeignKey("DoiTuongGia")]
        public string DoiTuongGiaId { get; set; }

        public DateTimeOffset? NgayKyHopDong { get; set; }

        public DateTimeOffset? NgayLapDat { get; set; }

        public string? GhiChu { get; set; }

        public string? Diachi { get; set; }


        public decimal KinhDo { get; set; }
        public decimal ViDo { get; set; }

        public DateTimeOffset? NgayCoHieuLuc { get; set; }

        [ForeignKey("TuyenDoc")]
        public string TuyenDocId { get; set; }

        public string MucDichSuDung { get; set; }

        public string? KhuVucTT { get; set; }

        public string? HinhThucTT { get; set; }

        public string? MaVach { get; set; }


        public string? NguoiLapDat { get; set; }
        public DateTime? NgayNT { get; set; }

        public decimal? TienLapDat { get; set; }
        public string? NguoiNop { get; set; }
        public decimal? TienDatCoc { get; set; }
        public GiamTru? GiamTruTheo { get; set; }
        public decimal? SoTien { get; set; }
        public DateTime? NgayDatCoc { get; set; }
        public string? ChungTu { get; set; }
        public bool? CamKetSuDungNuoc { get; set; }
        public string? KhoiLuongCamKet { get; set; }

        public virtual DoiTuongGiaEntity DoiTuongGia { get; set; }

        public virtual KhachHangEntity KhachHang { get; set; }

        public virtual TuyenDocEntity TuyenDoc { get; set; }

        public virtual ICollection<DongHoNuocEntity>? DongHoNuocs { get; set; }


    }
}
