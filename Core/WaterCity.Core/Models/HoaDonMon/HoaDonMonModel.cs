using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Core.Models.HoaDonMon
{
    public class HoaDonMonModel
    {
        public string? KeyId
        {
            get; set;
        }
        public DateTime NgayDat { get; set; }
        public string DiaChi { get; set; } = null!;
        public decimal TongTien { get; set; }
        public string TinhTrang { get; set; } = null!;
        public string MaKHID { get; set; } = null!;
    }
}
