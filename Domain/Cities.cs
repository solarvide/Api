using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cities : BaseEntityWithId
    {
        public string City { get; set; }
        public string Distributor { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal Irradiation { get; set; }
        public string LevelIrradiation { get; set; }
        public string Coordinates { get; set; }
        public int RatekWh { get; set; }
        public string UF { get; set; }
    }
}
