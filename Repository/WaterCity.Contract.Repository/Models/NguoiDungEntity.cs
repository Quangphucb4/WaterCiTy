using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("NguoiDung")]
    public class NguoiDungEntity : Entity
    {
       

        public string DangNhapId { get; set; }


        public string MatKhau { get; set; }


        public string Email { get; set; }



        public virtual ICollection<NhaMayEntity>? NhaMays { get; set; }

        public virtual ICollection<ChucNangEntity>? ChucNangs { get; set; }

        public virtual ICollection<ChucVuEntity>? ChucVus { get; set; }



    }
}
