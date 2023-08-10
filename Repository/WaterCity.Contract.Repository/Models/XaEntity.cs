using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    public class XaEntity: Entity
    {
        public string Ten { get; set; }
        [ForeignKey("Huyen")]
        public string HuyenId { get; set; }
        public virtual HuyenEntity? Huyen { get; set; }
    }
}
