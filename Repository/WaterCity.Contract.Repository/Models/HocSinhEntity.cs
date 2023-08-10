using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    public class HocSinhEntity : Entity
    {
        public string MaSV { get; set; } = null!;
        public string tenSV { get; set; } = null!;
        public string gioiTinh { get; set; } = null!;
        [ForeignKey("LopHoc")]
        public string MaLop { get; set; } = null!;
        public virtual ICollection<LopHocEntity> LopHocs { get; set; } = null!;
    }
}
