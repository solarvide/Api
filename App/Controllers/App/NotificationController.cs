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
using App.Dto.Notification;

namespace App.Controllers.App
{
    [Route("api/app/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {

        private readonly ContextApp _context;
        private readonly IMapper _mapper;
        private readonly SettingsApp _settingsApp;
        public NotificationController(ContextApp context, IMapper mapper, SettingsApp settings)
        {
            _context = context;
            _mapper = mapper;
            _settingsApp = settings;
        }

        [HttpPost("List/")]
        public ActionResult<ICollection<NotificationListResponseDto>> NotificationList()
        {
            try
            {
                var userId = Tools.TokenGetId(Request);

                DateTime dateInital = DateTime.Today;
                DateTime dateEnd = dateInital.AddDays(-7);

                var query = _context.Notifications
                    .Where(o => !o.Deleted && o.CreatedOn <= dateInital && o.CreatedOn >= dateEnd)
                    .OrderBy(o => o.Title);

                var notificationMapped = _mapper.Map<IEnumerable<Notification>, IEnumerable<NotificationListResponseDto>>(query);

                return Ok(new SuccessControlled
                {
                    Status = true,
                    Code = "success",
                    BaseUrlimage = _settingsApp.AwsS3.BaseUrlS3,
                    Data = notificationMapped
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
