using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {
    public class Country {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(10)]
        public string Abbreviation { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public int PhonePrefix { get; set; }
        public bool Deleted { get; set; }
    }
}
