using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    public class NuocSanXuatEntity : Entity
    {
        public string TenNuoc { get; set; }
        public ICollection<HangSanXuatEntity>? HangSanXuats { get; set; }
    }
}
