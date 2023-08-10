using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Core.Models.HocSinh
{
    public class HocSinhModel
    {
        public string KeyId { get; set; } = null!;
        public string MaSV { get; set; } = null!;
        public string tenSV { get; set; } = null!;
        public string gioiTinh { get; set; } = null!;
        public string MaLop { get; set; } = null!;
    }
}
