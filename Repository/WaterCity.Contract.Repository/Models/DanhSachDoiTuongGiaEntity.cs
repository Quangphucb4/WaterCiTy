
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    [Table("DanhSachDoiTuongGia")]
    public class DanhSachDoiTuongGiaEntity : Entity
    {
       // public string KyHieu { get; set; }
        public string MoTa { get; set; }
        public string DonViTinh { get; set; }

        public virtual ICollection<DoiTuongGiaEntity>? DoiTuongGias { get; set; }
        
    }
}
