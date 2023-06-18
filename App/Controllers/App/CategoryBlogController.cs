using App.Configurations;
using App.Dto.Blog;
using App.Dto.Default;
using AutoMapper;
using Context.Repo;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Util.Tools;
using Util;
using App.Dto.CategoryBlog;

namespace App.Controllers.App
{

    [Route("api/app/[controller]")]
    [ApiController]
    public class CategoryBlogController : ControllerBase
    {

        private readonly ContextApp _context;
        private readonly IMapper _mapper;
        private readonly SettingsApp _settingsApp;
        public CategoryBlogController(ContextApp context, IMapper mapper, SettingsApp settings)
        {
            _context = context;
            _mapper = mapper;
            _settingsApp = settings;
        }


        [HttpPost("List/")]
        public ActionResult<ICollection<CategoryBlogResponseDto>> ListCategoryBlog(DefaultRequestDto request)
        {
            try
            {

                // pagination
                request.QtyByPage = request.QtyByPage == 0 ? 99999 : request.QtyByPage;
                request.Page = request.Page == 0 ? 1 : request.Page;
                request.Skip = (request.Page - 1) * request.QtyByPage;

                var query = _context.CategoriesBlog
                    .Where(o => !o.Deleted && (string.IsNullOrEmpty(request.Filter) || o.Description.ToLower().Contains(request.Filter.ToLower())))
                    .OrderBy(o => o.Description);

                var totalList = query.Count();
                var result = query.Skip(request.Skip).Take(request.QtyByPage).ToList();
                double totalPage = Math.Ceiling(totalList / (double)request.QtyByPage);
                // response

                var categoryMapped = _mapper.Map<IEnumerable<CategoryBlog>, IEnumerable<CategoryBlogResponseDto>>(result);

                return Ok(new SuccessControlled
                {
                    Status = true,
                    Code = "success",
                    BaseUrlimage = _settingsApp.AwsS3.BaseUrlS3,
                    Paginate = new Paginate()
                    {
                        TotalPage = totalList,
                        TotalRegister = totalPage,
                        Skip = request.Skip,
                    },
                    Data = categoryMapped
                });
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
