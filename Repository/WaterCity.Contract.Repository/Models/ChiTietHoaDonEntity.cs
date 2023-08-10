
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    [Table("ChiTietHoaDon")]
    public class ChiTietHoaDonEntity : Entity
    {
        public decimal SoTieuThu { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        [ForeignKey("HoaDon")]
        public string HoaDonId { get; set; }
        public virtual HoaDonEntity HoaDon { get; set; }

    }
}
