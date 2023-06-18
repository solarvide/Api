using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class NotificationUsers: BaseEntityWithId
    {
        [ForeignKey("UserId")]
        public User User { get; set; }
        public long UserId { get; set; }

        [ForeignKey("NotificationId")]
        public Notification Notification { get; set; }
        public long NotificationId { get; set; }
    }
}
