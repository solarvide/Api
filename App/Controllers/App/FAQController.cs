using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using App.Configurations;
using Domain;
using Util;
using Context.Repo;
using APP.Dto.FAQ;

namespace App.Controllers.App
{
    [Route("api/[controller]/App")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        private readonly ContextApp _context;
        private readonly IMapper _mapper;
        private readonly SettingsApp _settingsApp;
        public FAQController(ContextApp context, IMapper mapper, SettingsApp settings)
        {
            _context = context;
            _mapper = mapper;
            _settingsApp = settings;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<ICollection<FAQListResponseDto>> List()
        {
            try
            {
                var result = _context.FAQs.ToList();
                var FAQMapped = _mapper.Map<IEnumerable<FAQ>, IEnumerable<FAQListResponseDto>>(result);
                return Ok(FAQMapped);
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
        public async Task<ActionResult> Create(FAQDefaultRequestDto request)
        {
            try
            {

                var FAQ = _mapper.Map<FAQDefaultRequestDto, FAQ>(request);

                _context.Add(FAQ);

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

        [HttpPut("{faqId}")]
        public async Task<ActionResult> UpdateFaq(long faqId, FAQDefaultRequestDto request)
        {
            try
            {
                var faq = _context.FAQs.Where(o => o.Id == faqId).FirstOrDefault();

                if (faq == null) throw new ExceptionControlled("Error FAQ not Found", false, false);

                if (request.Question != null) faq.Question = request.Question;

                if (request.Answer != null) faq.Answer = request.Answer;

                _context.Update(faq);
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

