using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    public class HangSanXuatEntity : Entity
    {
        public string TenHang { get; set; }
        [ForeignKey("NuocSanXuat")]
        public string NuocSanXuatId { get; set; }
        public virtual NuocSanXuatEntity NuocSanXuat { get; set; }
    }
}
