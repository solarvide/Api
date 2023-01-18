using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {
    public class CodeValidation: Base.BaseEntityWithIdWithoutChange {
        [MaxLength(25)]
        public string  ValidationCode { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CodeType { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
        public long UserId { get; set; }
       

    }
}
