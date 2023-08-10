using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    [Table("KhachHangMon")]
    public class KhachHangMonEntity : Entity
    {
        public string TenKh { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public string SDT { get; set; } = null!;
        public string GioiTinh { get; set; } = null!;
        ICollection<HoaDonMonEntity> hoaDonMons { get; set; }=null!;

    }
}
