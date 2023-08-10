using System.ComponentModel.DataAnnotations.Schema;
using WaterCity.Core.EnumCore;

namespace WaterCity.Contract.Repository.Models
{
    [Table("LichSuSMS")]

    public class LichSuSMSEntity : Entity
    {
        public string NguoiGuidId { get; set; }
        public string KhachHangId { get; set; }
        public string HoaDonId { get; set; }
        public string HopDongId { get; set; }
        public string SoDienThoai { get; set; }
        public string ThongTin { get; set; }
        public string NoiDung { get; set; }
        public TrangThaiThongBao TrangThaiGui { get; set; }
        [ForeignKey("MauTinSMS")]
        public string MauTinSMSId { get; set; }
        public virtual MauTinSMSEntity MauTinSMS { get;set; }
      
    }
}
