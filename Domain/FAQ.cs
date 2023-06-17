using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FAQ:BaseEntityWithId
    {
        [Column(TypeName = "ntext")]
        public string Question { get; set; }

        [Column(TypeName = "ntext")]
        public string Answer { get; set; }
    }
}
