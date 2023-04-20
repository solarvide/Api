using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CategoryBlog : BaseEntityWithId
    {
        public string Description { get; set; }
        public bool status { get; set; }
    }
}
