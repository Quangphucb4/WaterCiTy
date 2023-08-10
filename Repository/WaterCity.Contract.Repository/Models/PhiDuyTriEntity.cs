using System.ComponentModel.DataAnnotations.Schema;
using WaterCity.Core.EnumCore;

namespace WaterCity.Contract.Repository.Models
{
    [Table("PhiDuyTri")]

    public class PhiDuyTriEntity : Entity
    {

        public CachTinhPhiDuyTri KieuTinh { get; set; }
        public decimal DonGia { get; set; }
        public decimal? VAT { get; set; }
        public decimal? ApDungKhiTieuThu { get; set; }
        public ICollection<DoiTuongGiaEntity>? DoiTuongGias { get; set; }
    }
}
