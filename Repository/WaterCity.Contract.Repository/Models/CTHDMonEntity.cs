using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    [Table("CTHDMon")]
    public class CTHDMonEntity : Entity
    {
        [Range(0, 100)]
        public decimal SoLuong {get; set;}
        [Range(0, double.MaxValue)]
        public double DonGia { get; set;}
        [ForeignKey("Mon")]
        public string MonID { get; set; } = null!;
        [ForeignKey("HoaDonMon")]
        public string MaHDID { get; set; } = null!;
        public virtual MonEntity mons { get; set; }=null!;
        public virtual HoaDonMonEntity HoaDonMon { get; set; } = null!;
    }
}
