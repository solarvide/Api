using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class NotificationScheduler : BaseEntityWithId
    {
        [ForeignKey("UserId")]
        public User User { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Mensage { get; set; }
        public bool Read { get; set; }
    }
}
