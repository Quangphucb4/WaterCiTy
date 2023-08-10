using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    [Table("ChiTietGia")]
    public class ChiTietGiaEntity : Entity
    {
      
        public string MoTaChiTiet { get; set; } 
        public decimal TuSo { get; set; }
        public decimal DenSo { get; set; }
        public decimal GiaCoVat { get; set; }
        public decimal Gia { get; set; }

        [ForeignKey("DoiTuongGia")]
        public string? DoiTuongGiaId { get; set; }
        public virtual DoiTuongGiaEntity? DoiTuongGia { get; set; }
    }
}
