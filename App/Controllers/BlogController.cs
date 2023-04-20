using App.Configurations;
using AutoMapper;
using Context.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Dto.Blog;
using Util;
using Domain;
using App.Dto.Default;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private readonly ContextApp _context;
        private readonly IMapper _mapper;
        private readonly SettingsApp _settingsApp;
        public BlogController(ContextApp context, IMapper mapper, SettingsApp settings)
        {
            _context = context;
            _mapper = mapper;
            _settingsApp = settings;
        }

        [HttpGet("{blogId}")]
        public async Task<ActionResult<BlogListResponseDto>> GetNews(long blogId)
        {
            try
            {
                var blog = _context.Blogs
                    .Include(o=>o.CategoryBlog)
                    .Where(o => o.Id == blogId).FirstOrDefault();
                if (blog == null)
                {
                    throw new ExceptionControlled("News Found", false, false);
                }

                var blogMapped = _mapper.Map<Blog, BlogListResponseDto>(blog);

                return Ok(blogMapped);
            }
            catch (ExceptionControlled ex)
            {
                return BadRequest(ex.ResponseToJson());
            }
            catch (Exception ex)
            {

                return BadRequest(ExceptionControlled.ResponseToJson(ex));
            }
        }
        [HttpGet("List/")]

        public ActionResult<ICollection<BlogListResponseDto>> ListNews(DefaultRequestDto request)
        {
            try
            {

                // pagination
                request.QtyByPage = request.QtyByPage == 0 ? 99999 : request.QtyByPage;
                request.Page = request.Page == 0 ? 1 : request.Page;
                request.Skip = (request.Page - 1) * request.QtyByPage;

                var query = _context.Blogs
                     .Include(o => o.CategoryBlog)
                    .Where(o => !o.Deleted && (string.IsNullOrEmpty(request.Filter) || o.Title.ToLower().Contains(request.Filter.ToLower())))
                    .OrderBy(o => o.Title);

                var totalList = query.Count();
                var result = query.Skip(request.Skip).Take(request.QtyByPage).ToList();
                double totalPage = Math.Ceiling(totalList / (double)request.QtyByPage);
                // response
                var blogMapped = _mapper.Map<IEnumerable<Blog>, IEnumerable<BlogListResponseDto>>(result);

                return Ok(new { TotalRegister = totalList, TotalPage = totalPage, BaseUrlimage = _settingsApp.AwsS3.BaseUrlS3, Data = blogMapped });

            }
            catch (ExceptionControlled ex)
            {
                return BadRequest(ex.ResponseToJson());
            }
            catch (Exception ex)
            {

                return BadRequest(ExceptionControlled.ResponseToJson(ex));
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateNews(BlogRequestDto request)
        {
            try
            {
                if (request.ImageURL != null)
                {
                    var basecheck = request.ImageURL.Split(",");
                    byte[] bytescheck = Convert.FromBase64String(basecheck[1]);

                    var typeImage = basecheck[0].Split("/");
                    typeImage = typeImage[1].Split(";");
                    if (typeImage[0] == "webp")
                    {
                        var msg1 = Translator.Transl("type_image_not_valid_msg", "Type of Image not valid", Request);
                        var msg2 = Translator.Transl("type_image_not_valid_title", "Invalid Image", Request);
                        throw new ExceptionControlled(msg1, msg2);
                    }

                    var imgUrl = await Tools.UploadFileToS3(_settingsApp.AwsS3.KeyS3, _settingsApp.AwsS3.SecretKeyS3, _settingsApp.AwsS3.BucketName, request.ImageURL, true, Convert.ToInt32(ConfigTag.GetValue("default_percent_compress")));
                    request.ImageURL = imgUrl;
                }

                var blogMapped = _mapper.Map<BlogRequestDto, Blog>(request);
                _context.Add(blogMapped);
                _context.SaveChanges();
                return Ok();
            }
            catch (ExceptionControlled ex)
            {
                return BadRequest(ex.ResponseToJson());
            }
            catch (Exception ex)
            {

                return BadRequest(ExceptionControlled.ResponseToJson(ex));
            }
        }

        [HttpPut("{blogId}")]
        public async Task<ActionResult> UpdateNews(long blogId, BlogRequestDto request)
        {

            var blog = _context.Blogs.Where(o => o.Id == blogId).FirstOrDefault();

            if (blog == null) throw new ExceptionControlled("Article not Found", false, false);

            if (request.ImageURL != null)
            {
                Tools.S3DeleteItem(_settingsApp.AwsS3.KeyS3, _settingsApp.AwsS3.SecretKeyS3, _settingsApp.AwsS3.BucketName, blog.ImageURL);
                blog.ImageURL = await Tools.UploadFileToS3(_settingsApp.AwsS3.KeyS3, _settingsApp.AwsS3.SecretKeyS3, _settingsApp.AwsS3.BucketName, request.ImageURL, true, Convert.ToInt32(ConfigTag.GetValue("default_percent_compress")));
            }

            if (request.Title != null) blog.Title = request.Title;

            if (request.Text != null) blog.Text = request.Text;
            if (request.CategoryBlogId != null) blog.CategoryBlogId = request.CategoryBlogId;

            _context.Update(blog);
            _context.SaveChanges();

            return Ok();

        }

        [HttpDelete("{blogId}")]
        public async Task<ActionResult> Delete(long newsId)
        {
            try
            {
                var blog = _context.Blogs.Where(o => o.Id == newsId).FirstOrDefault();
                if (blog == null) throw new ExceptionControlled("Article not found", false, false);
                _context.Remove(blog);
                _context.SaveChanges();
                return Ok();

            }
            catch (ExceptionControlled ex)
            {
                return BadRequest(ex.ResponseToJson());
            }
            catch (Exception ex)
            {

                return BadRequest(ExceptionControlled.ResponseToJson(ex));
            }

        }


    }


}
