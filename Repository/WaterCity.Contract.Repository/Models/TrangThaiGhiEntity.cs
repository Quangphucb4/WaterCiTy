using WaterCity.Contract.Repository.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("TrangThaiGhi")]
    public class TrangThaiGhiEntity : Entity
    {

        public string TenTrangThai { get; set; }
        public string MaMau { get; set; }
        public string? MoTaNgan { get; set; }
        public int? SoTt { get; set; }
        public bool? KhongChoPhepGhi { get; set; }
        public bool? KhongChoPhepHienThi { get; set; }

        public virtual ICollection<ChiSoDongHoEntity>? ChiSoDongHos { get; set; }
    }
}
