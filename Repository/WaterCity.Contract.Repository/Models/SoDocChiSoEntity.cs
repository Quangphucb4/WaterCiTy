using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("SoDocChiSo")]
    public class SoDocChiSoEntity : Entity
    {
        [ForeignKey("TuyenDoc")]
        public string? TuyenDocId { get; set; }
        public string? NhaMayId { get; set; }
        public string NguoiDungId { get; set; }

        [ForeignKey("KyGhiChiSo")]
        public string KyGhiChiSoId { get; set; }
        public string TenSo { get; set; }
        public int? SoDhdaGhi { get; set; }
        public bool? ChotSo { get; set; }
        public string? TrangThai { get; set; }
        public DateTimeOffset? NgayChot { get; set; }
        public string? HoaDon { get; set; }

        public virtual KyGhiChiSoEntity? KyGhiChiSo { get; set; }
        public virtual TuyenDocEntity? TuyenDoc { get; set; }
        public virtual ICollection<ChiSoDongHoEntity>? ChiSoDongHos { get; set; }
    }
}
