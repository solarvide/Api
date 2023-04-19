using App.Configurations;
using App.Dto.Company;
using App.Dto.Default;
using App.DtoUsers;
using AutoMapper;
using Context.Repo;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Util;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ContextApp _context;
        private readonly IMapper _mapper;
        private readonly SettingsApp _settingsApp;

        public CompanyController(ContextApp context, IMapper mapper, SettingsApp settings)
        {
            _context = context;
            _mapper = mapper;
            _settingsApp = settings;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<List<CompanyCitiesResponseDto>> ListCompanyCities()
        {
            try
            {
                var companyCities = _context.Companies.Where(o => !o.Deleted).ToList();

                var companyMapped = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyCitiesResponseDto>>(companyCities);
                return Ok(companyMapped);
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
