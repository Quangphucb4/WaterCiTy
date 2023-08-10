using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Core.Models.KhachHangMon
{
    public class KhachHangMonModel
    {
        public string? KeyId
        {
            get; set;
        }
        public string TenKh { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public string SDT { get; set; } = null!;
        public string GioiTinh { get; set; } = null!;
    }
}
