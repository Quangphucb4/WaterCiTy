using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("Vung")]
    public class VungEntity : Entity
    {

        public string? NhaMayId { get; set; }
       
        public string TenVung { get; set; }

        public virtual ICollection<KhuVucEntity>? KhuVucs { get; set; }
    }
}
