using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Scheduler : BaseEntityWithId
    {
        [ForeignKey("CompanyId")]
        [Required]
        public Company Company { get; set; }
        public long CompanyId { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public User User { get; set; }
        public long UserId { get; set; }
        public DateTime DateInitial { get; set; }
        public DateTime DateEnd { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string PhoneContact { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Distric { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string UF { get; set; }
    }
}
