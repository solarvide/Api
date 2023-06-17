using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class NetworkEnergy : BaseEntityWithId
    {
       public string InstalationType { get; set; }
       public int MinimalkWh { get; set; }
    }
}
