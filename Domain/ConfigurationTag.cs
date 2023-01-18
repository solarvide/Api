using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {
    public class ConfigurationTag {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [MaxLength(50)]
        public string Tag { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }
        [MaxLength(4000)]
        public string Value { get; set; }

    }
}
