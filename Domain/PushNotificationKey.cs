using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain {
    public class PushNotificationKey : Base.BaseEntity {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string PushKey { get; set; }
        public string PublicIP { get; set; }
        public User User { get; set; }
    }
}
