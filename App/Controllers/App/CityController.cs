using App.Configurations;
using AutoMapper;
using Context.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Dto.Blog;
using Util;
using Domain;
using App.Dto.Default;
using App.Dto.Cities;
using Microsoft.AspNetCore.Authorization;

namespace App.Controllers.App
{
    [Route("api/[controller]/App")]
    [ApiController]
    public class CityController : ControllerBase
    {

        private readonly ContextApp _context;
        private readonly IMapper _mapper;
        private readonly SettingsApp _settingsApp;
        public CityController(ContextApp context, IMapper mapper, SettingsApp settings)
        {
            _context = context;
            _mapper = mapper;
            _settingsApp = settings;
        }

        [AllowAnonymous]
        [HttpPost("List/")]
        public ActionResult<ICollection<CitiesResponseDto>> ListCity(CitiesListRequestDto request)
        {
            try
            {

                // pagination
                request.QtyByPage = request.QtyByPage == 0 ? 99999 : request.QtyByPage;
                request.Page = request.Page == 0 ? 1 : request.Page;
                request.Skip = (request.Page - 1) * request.QtyByPage;

                var query = _context.Cities
                    .Where(o => !o.Deleted
                    && o.UF == request.UF.ToLower()
                    && (string.IsNullOrEmpty(request.Filter) || o.Distributor.ToLower().Contains(request.Filter.ToLower()) || o.City.ToLower().Contains(request.Filter.ToLower())))
                    .OrderBy(o => o.City);

                var totalList = query.Count();
                var result = query.Skip(request.Skip).Take(request.QtyByPage).ToList();
                double totalPage = Math.Ceiling(totalList / (double)request.QtyByPage);
                // response
                var citiesMapped = _mapper.Map<IEnumerable<Cities>, IEnumerable<CitiesResponseDto>>(result);
                return Ok(new { TotalRegister = totalList, TotalPage = totalPage, BaseUrlimage = _settingsApp.AwsS3.BaseUrlS3, Data = citiesMapped });
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
