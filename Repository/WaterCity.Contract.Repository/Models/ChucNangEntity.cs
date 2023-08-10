
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    [Table("ChucNang")]

    public class ChucNangEntity : Entity
    {
        public string? TenChucNang { get; set; }
        [ForeignKey("NguoiDung")]
        public string? NguoiDungId { get; set; }

        public virtual ICollection<NguoiDungEntity>? NguoiDungs { get; set; }
    }
}
