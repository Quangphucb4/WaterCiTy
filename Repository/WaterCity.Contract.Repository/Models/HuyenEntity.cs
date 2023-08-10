using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    public class HuyenEntity : Entity
    {
        public string Ten { get; set; }
        [ForeignKey("Tinh")]
        public string TinhId { get; set; }
        public virtual TinhEntity? Tinh { get; set; }

        public virtual ICollection<XaEntity> Xas { get; set; }
    }
}
