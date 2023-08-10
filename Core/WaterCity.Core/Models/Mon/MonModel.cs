using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Core.Models.Mon
{
    public class MonModel
    {
        public string? KeyId
        {
            get; set;
        }
        public string TenMon { get; set; } = null!;
        public string LoaiMonID { get; set; } = null!;
        public string Mota { get; set; } = null!;
    }
}
