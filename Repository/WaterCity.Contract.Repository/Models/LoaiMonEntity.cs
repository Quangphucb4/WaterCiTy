using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    [Table("LoaiMon")]
    public class LoaiMonEntity : Entity
    {
        public string TenLoai { get; set; } = null!;
        public string MoTa { get; set; } = null!;
        public ICollection<MonEntity> mons { get; set; } = null!;
    }
}
