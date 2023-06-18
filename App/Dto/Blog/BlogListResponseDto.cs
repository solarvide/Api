
using App.Dto.CategoryBlog;
using App.Dto.Default;

namespace App.Dto.Blog
{
    public class BlogListResponseDto
    {
        public long CategoryBlogId { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }
        public CategoryBlogResponseDto CategoryBlog { get; set; }

    }
}
