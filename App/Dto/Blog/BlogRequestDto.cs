
namespace App.Dto.Blog
{ 
    public class BlogRequestDto {
        public long Category { get; set; }
        public string? ImageURL { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public long CategoryBlogId { get; set; }
    }
}
