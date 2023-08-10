using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Core.Models.CTHDMon
{
    public class CTHDMonModel
    {
        public string? KeyId
        {
            get; set;
        }
        public decimal SoLuong { get; set; }
        public double DonGia { get; set; }
        public string MonID { get; set; } = null!;
        public string MaHDID { get; set; } = null!;
    }
}
