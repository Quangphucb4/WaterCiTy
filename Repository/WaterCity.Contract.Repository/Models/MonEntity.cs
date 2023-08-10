using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    [Table("Mon")]
    public class MonEntity : Entity
    {
        public string TenMon { get; set; } = null!;
        [ForeignKey("LoaiMon")]
        public string LoaiMonID { get; set; } = null!;
        public string Mota {get; set; }=null!;
        public virtual LoaiMonEntity Loai { get; set; } = null!;
        ICollection<HoaDonMonEntity> hoaDonMons { get; set; } = null!;
        ICollection<CTHDMonEntity> CTHDMons { get; set; } = null!;


    }
}
