using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    [Table("HoaDonMon")]
    public class HoaDonMonEntity :Entity
    {
        public DateTime NgayDat {  get; set; }
        public string DiaChi { get; set; } = null!;
        public decimal TongTien { get; set; }
        public string TinhTrang { get; set; }=null!;
        [ForeignKey("KhachHangMon")]
        public string MaKHID { get; set; } = null!;
        public virtual KhachHangMonEntity KhachHangmons { get; set; } = null!;
        ICollection<MonEntity> Mons { get; set; } = null!;
        ICollection<CTHDMonEntity> CTHDMons { get; set; } = null!;
    }
}
