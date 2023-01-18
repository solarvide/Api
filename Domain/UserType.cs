using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain {
    public class UserType: Base.BaseEntityWithId {
        [MaxLength(20)]
        [Required]
        public string Abbreviation { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Name { get; set; }

    }
}
