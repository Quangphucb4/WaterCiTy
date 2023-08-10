using System.ComponentModel.DataAnnotations.Schema;

namespace WaterCity.Contract.Repository.Models
{
    [Table("MauTinSMS")]

    public class MauTinSMSEntity : Entity
    { 
        public string NoiDung { get; set; }
        public string ApiEndPoint { get; set; }

        public ICollection<LichSuSMSEntity>? LichSuSMSs { get;set; }
    }
}
