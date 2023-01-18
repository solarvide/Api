using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base {
    public class BaseEntity {
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        
        [DefaultValue(false)]
        public bool Deleted { get; set; }



    }
}
