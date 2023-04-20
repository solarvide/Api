namespace App.Dto.Blog
{
    public class BlogListRequestDto {
        public int QtyByPage { get; set; }
        public int Page { get; set; }
        public string Filter { get; set; }
    }
}
