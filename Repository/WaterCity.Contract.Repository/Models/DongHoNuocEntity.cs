using System.ComponentModel.DataAnnotations.Schema;
using WaterCity.Core.EnumCore;

namespace WaterCity.Contract.Repository.Models
{
    [Table("DongHoNuoc")]
    public class DongHoNuocEntity : Entity
    {
        //DonViHanhChinh FE se Map tu 3 bang Tinh, Huyen, Xa
        public string? DonViHC { get; set; }
        public string? LoaiDongHo { get; set; }
        public string? NguoiQuanLyId { get; set; }
        [ForeignKey("PhamVi")]
        public string? PhamViId { get; set; }
        public virtual PhamViEntity? PhamVi { get; set; }
        public string? SeriDongHo { get; set; }
        public string SeriChi { get; set; }
        public TrangThaiSuDung? TrangThaiSuDung { get; set; }
        public string? LyDoHuyId { get; set; }
        public string? NuocSXId { get; set; }
        public string? HangSXId { get; set; }
        public string? KieuDongHoId{ get; set; }
        public HopBaoVe? HopBaoVe { get; set; }
        public LyDoKiemDinh? LyDoKiemDinh { get; set; }
        public bool? VanMotChieu { get; set; }
        public HinhThucXuLy? HinhThucXL { get; set; }
        public LyDoThay? LyDoThay { get; set; }
        public LoaiKhuyenMai? LoaiKM { get; set; }
        public bool? TrangThaiDHLap {get; set; }
        public decimal? ChiSoDau { get; set; }
        public decimal? ChiSoCuoi { get; set; }
        public int? SoThuTu { get; set; }
        [ForeignKey("HopDong")]
        public string? HopDongId { get; set; }

        public virtual HopDongEntity? HopDong { get; set; }


        [ForeignKey("DongHoNuoc")]
        public string? DongHoChaId { get; set; }

        public string? DiaChi { get; set; }
        public decimal? DuongKinh { get; set; }
        public string? ViTriLapDat { get; set; }
        public DateTimeOffset NgayKiemDinh { get; set; }
        public DateTimeOffset HieuLucKD { get; set; }
        public string? SoTem { get; set; }
        public string? SoPhieuThay { get; set; }
        public string? MaDHThay { get; set; }

        public string? NguoiThayId { get; set; }
        public decimal? KhuyenMai { get; set; }
        public string? OngDan { get; set; }
        public string? DaiKhoiThuy { get; set; }
        
        public virtual ICollection<DongHoNuocEntity>? DongHoCons { get; set; }

        public virtual ICollection<ChiSoDongHoEntity>? ChiSoDongHos { get; set; }
        public virtual ICollection<DongHoNuocSuCoEntity>? DongHoNuocSuCos { get; set; }
        public virtual ICollection<ThatThoatEntity>? ThatThoats { get; set; }
    }
}
