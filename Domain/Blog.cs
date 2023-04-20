using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Blog: BaseEntityWithId
    {
        public string ImageURL { get; set; }

        [MaxLength(500)]
        public string Title { get; set; }
        public string Text { get; set; }

        [ForeignKey("CategoryId")]
        public CategoryBlog CategoryBlog { get; set; }
        public long CategoryBlogId { get; set; }
      
    }
}
