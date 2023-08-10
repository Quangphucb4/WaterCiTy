using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    public class LopHocEntity : Entity
    {
        [MaxLength(100)]
        public string MaLop { get; set; } = null!;
        public string tenLop { get; set; } = null!;
        [Range(0, 100)]
        public int soLuong { get; set; }
        ICollection<HocSinhEntity> hocSinhs { get; set; } = null!;

    }
}