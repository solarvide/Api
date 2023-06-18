using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BlogUserRead: BaseEntityWithId
    {
        [ForeignKey("UserId")]
        public User User { get; set; }
        public long UserId { get; set; }
        
        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }
        public long BlogId { get; set; }

    }
}
