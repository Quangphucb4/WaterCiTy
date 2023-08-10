
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("HoaDon")]
    public class HoaDonEntity : Entity
    {

        public string TrangThaiThanhToan { get; set; }


        //[ForeignKey("NguoiThuTien")]
        public string NguoiThuTienId { get; set; }

        public string GhiChu { get; set; }

        public decimal TongTienTruocVat { get; set; }

        public decimal Vat { get; set; }


        public decimal PhiDtdn { get; set; }

        public decimal? PhiBvmt { get; set; }



        [ForeignKey("DanhMucSeriHoaDon")]
        public string SeriHoaDon { get; set; }

        public virtual DanhMucSeriHoaDonEntity DanhMucSeriHoaDon { get; set; }


        [ForeignKey("ChiSoDongHo")]
        public string ChiSoDongHoId { get; set; }

        public virtual ChiSoDongHoEntity ChiSoDongHo { get; set; }


        [ForeignKey("PhienInThongBao")]
        public string? PhienInThongBaoId { get; set; }

        public virtual PhienInThongBaoEntity? PhienInThongBao { get; set; }

        public virtual ICollection<ThongBaoEntity>? ThongBaos { get; set; }


        public virtual ICollection<ChiTietHoaDonEntity>? ChiTietHoaDons { get; set; }


        public virtual ICollection<NhatKyHoaDonEntity>? NhatKyHoaDons { get; set; }

    }
}
