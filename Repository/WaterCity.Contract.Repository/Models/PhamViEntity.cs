using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    public class PhamViEntity: Entity
    {
        public string TenPhamVi { get; set; }
        public ICollection<DongHoNuocEntity> DongHoNuocs { get; set; }
    }
}
