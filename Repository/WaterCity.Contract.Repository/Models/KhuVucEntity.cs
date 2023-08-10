using System.ComponentModel.DataAnnotations.Schema;
namespace WaterCity.Contract.Repository.Models
{
    [Table("KhuVuc")]
    public class KhuVucEntity : Entity
    {
       
        public string TenKhuVuc { get; set; }


        [ForeignKey("Vung")]
        public string VungId { get; set; }

        public virtual VungEntity? Vung { get; set; }

        public virtual ICollection<TuyenDocEntity>? TuyenDocs { get; set; }

        public virtual ICollection<DanhSachHoDanEntity>? DanhSachHoDans { get; set; }

    }
}
