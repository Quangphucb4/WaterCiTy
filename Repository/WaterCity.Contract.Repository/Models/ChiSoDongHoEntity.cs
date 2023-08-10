using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    [Table("ChiSoDongHo")]
    public class ChiSoDongHoEntity : Entity
    {
        public int ChiSoCu { get; set; }
        public int ChiSoMoi { get; set; }
        public DateTimeOffset NgayDoc { get; set; }
        public DateTimeOffset? NgayDongBo { get; set; }

        public int? ChiSoDauCu { get; set; }
        public int? ChiSoCuoiCu { get; set; }
        public string? GhiChu { get; set; }
        public string? Tthu { get; set; }

        [ForeignKey("DongHoNuoc")]
        public string DongHoNuocId { get; set; }
        public virtual DongHoNuocEntity DongHoNuoc { get; set; }


        [ForeignKey("SoDocChiSo")]
        public string SoDocChiSoId { get; set; }
        public virtual SoDocChiSoEntity SoDocChiSo { get; set; }


        [ForeignKey("TrangThaiGhi")]
        public string? TrangThaiGhiId { get; set; }
        public virtual TrangThaiGhiEntity TrangThaiGhi { get; set; }
        public virtual ICollection<HoaDonEntity>? HoaDons
        {
            get; set;
        }
    }
}
