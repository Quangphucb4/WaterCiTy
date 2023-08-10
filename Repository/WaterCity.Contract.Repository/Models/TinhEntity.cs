using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterCity.Contract.Repository.Models
{
    public class TinhEntity : Entity
    {
        public string Ten { get; set; }
        public virtual ICollection<HuyenEntity>? Huyens { get; set; }
    }
}
