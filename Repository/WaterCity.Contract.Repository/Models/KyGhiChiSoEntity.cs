
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("KyGhiChiSo")]
    public class KyGhiChiSoEntity : Entity
    {

        public string MoTa { get; set; }

        public DateTimeOffset NgaySuDungTu { get; set; }

        public DateTimeOffset NgaySuDungDen { get; set; }

        public DateTimeOffset NgayHoaDon { get; set; }


        // [ForeignKey("NhaMay")]
        public string NhaMayId { get; set; }

        public virtual ICollection<SoDocChiSoEntity>? SoDocChiSos { get; set; }

    }
}
