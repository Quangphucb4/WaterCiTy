using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Core.Models.LoaiMon
{
    public class LoaiMonModel
    {
        public string? KeyId
        {
            get; set;
        }
        public string TenLoai { get; set; } = null!;
        public string MoTa { get; set; } = null!;

    }
}
