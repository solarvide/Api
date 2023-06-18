using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Notification: BaseEntityWithId
    {
        public string Text { get; set; }
        public string Title { get; set; }
    }
}
