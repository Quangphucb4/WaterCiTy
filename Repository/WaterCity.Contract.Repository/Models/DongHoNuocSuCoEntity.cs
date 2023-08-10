using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("DongHoNuocSuCo")]
    public class DongHoNuocSuCoEntity : Entity
    {
        public DateTimeOffset NgaySuCo { get; set; }
        public string NguoiBaoCaoId { get; set; }
        public string NguoiThucHienId { get; set; }
        public int TienDo { get; set; }
        public string CachKhacPhuc { get; set; }

        [ForeignKey("DongHoNuoc")]
        public string DongHoNuocId { get; set; }
        public virtual DongHoNuocEntity DongHoNuoc { get; set; }

        [ForeignKey("SuCo")]
        public string SuCoId { get; set; }
        public virtual SuCoEntity SuCo { get; set; }
    }
}
