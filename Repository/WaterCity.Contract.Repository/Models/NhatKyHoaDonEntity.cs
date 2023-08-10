using WaterCity.Contract.Repository.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("NhatKyHoaDon")]
    public class NhatKyHoaDonEntity : Entity
    {
       
        public string NguoiDungId { get; set; }
        public DateTimeOffset NgaySua { get; set; }
        public string NoiDung { get; set; }

        [ForeignKey("HoaDon")]
        public string? HoaDonId { get; set; }
        public virtual HoaDonEntity? HoaDon { get; set; }
    }
}
