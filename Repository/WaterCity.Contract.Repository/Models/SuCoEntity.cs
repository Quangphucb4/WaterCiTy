using WaterCity.Contract.Repository.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("SuCo")]
    public class SuCoEntity : Entity
    {
        public string MoTa { get; set; }
        public string? TenSuCo { get; set; }

        public virtual ICollection<DongHoNuocSuCoEntity>? DongHoNuocSuCos { get; set; }
    }
}
