
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    [Table("ChucVu")]

    public class ChucVuEntity : Entity
    {
        public string? TenChucVu { get; set; }
        [ForeignKey("NguoiDung")]
        public string? NguoiDungId { get; set; }

        public virtual ICollection<NguoiDungEntity>? NguoiDungs { get; set; }
    }
}
