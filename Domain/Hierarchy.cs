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
    public class Hierarchy : BaseEntityWithId
    {
        [ForeignKey("ManagerId")]
        [Required]
        public User Manager { get; set; }
        public long ManagerId { get; set; }

        [ForeignKey("ExecutiveId")]
        [Required]
        public User Executive { get; set; }
        public long ExecutiveId { get; set; }
    }
}
