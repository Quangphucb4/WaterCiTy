using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    [Table("PhuongThucThanhToan")]

    public class PhuongThucThanhToanEntity : Entity
    {
        public string MoTaPhuongThuc { get ; set; }

    }
}
