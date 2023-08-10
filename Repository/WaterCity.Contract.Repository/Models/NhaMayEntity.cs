using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("NhaMay")]
    public class NhaMayEntity : Entity
    {
        public string TenNhaMay { get; set; }

        public string DiaChi { get; set; }

        public ICollection<NguoiDungEntity>? NguoiDungs { get;set; }
    }
}
