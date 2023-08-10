using WaterCity.Contract.Repository.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("ThatThoat")]
    public class ThatThoatEntity : Entity 
    {
        public DateTimeOffset ThoiGian { get; set; }
        public decimal? SoLuong { get; set; }
        public decimal? XucXa { get; set; }
        public decimal? CongIch { get; set; }
        public decimal? Khac { get; set; }
        public decimal? Sldhc { get; set; }

        [ForeignKey("DongHoNuoc")]
        public string DongHoNuocId { get; set; }

        public virtual DongHoNuocEntity DongHoNuoc { get; set; }
    }
}
