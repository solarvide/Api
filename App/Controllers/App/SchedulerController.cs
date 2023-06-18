using App.Configurations;
using App.Dto.Default;
using App.Dto.Scheduler;
using AutoMapper;
using Context.Repo;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using Util;

namespace App.Controllers.App
{
    [Route("api/[controller]/App")]
    [ApiController]
    public class SchedulerController : Controller
    {
        private readonly ContextApp _context;
        private readonly IMapper _mapper;
        private readonly SettingsApp _settingsApp;

        public SchedulerController(ContextApp context, IMapper mapper, SettingsApp settings)
        {
            _context = context;
            _mapper = mapper;
            _settingsApp = settings;
        }

        [HttpGet("{schedulerId}")]
        public async Task<ActionResult<SchedulerResponseDto>> GetScheduler(long schedulerId)
        {
            var userToken = Tools.TokenGetUser(Request);
            var scheduler = _context.Schedulers.Include(o => o.User).Include(o => o.Company).Where(o => o.Id == schedulerId).FirstOrDefault();
            if (scheduler == null)
            {
                throw new ExceptionControlled("Scheduler not Found", false, false);
            }

            var schedulerMapped = _mapper.Map<Scheduler, SchedulerResponseDto>(scheduler);
            return Ok(schedulerMapped);
        }



        [HttpPost]
        public async Task<ActionResult> Add(SchedulerRequestDto request)
        {
            try
            {
                var userToken = Tools.TokenGetUser(Request);
                var scheduler = _mapper.Map<SchedulerRequestDto, Scheduler>(request);
                scheduler.CompanyId = userToken.Company;
                scheduler.UserId = userToken.uID;
                _context.Add(scheduler);

                var manager = _context.Companies.Where(o => o.Id == userToken.Company).FirstOrDefault();
                var title = "Nova agenda";
                var mensage = "Ola! o representante" + userToken.Name + "Criou uma nova agenda";

                if (manager != null)
                {
                    var pushKey = _context.PushNotificationKeys.Where(o => o.User.Id == manager.UserId).OrderByDescending(o => o.Id).ToList();
                    var notify = new NotificationScheduler()
                    {
                        Title = title,
                        Mensage = mensage,
                        UserId = (long)manager.UserId,
                        Read = false,
                        CreatedOn = DateTime.Now,
                    };
                    _context.Add(notify);

                    foreach (var psuh in pushKey)
                    {
                        await Tools.Notification(title, mensage, psuh.PushKey);
                    }

                }
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

        [HttpGet("List/")]
        public ActionResult<List<SchedulerResponseDto>> ListScheduler(DefaultRequestDto request)
        {
            try
            {
                var userToken = Tools.TokenGetUser(Request);

                request.QtyByPage = request.QtyByPage == 0 ? 99 : request.QtyByPage;
                request.Page = request.Page == 0 ? 1 : request.Page;
                request.Skip = (request.Page - 1) * request.QtyByPage;

                var query = _context.Schedulers
                    .Where(o => o.CompanyId == userToken.Company && !o.Deleted && o.UserId == userToken.uID && o.DateInitial >= DateTime.Now.AddMonths(-2))
                    .OrderByDescending(o => o.DateInitial);
                int totalList = query.Count();
                var result = query.Skip(request.Skip).Take(request.QtyByPage);
                double totalPage = Math.Ceiling(totalList / (double)request.QtyByPage);
                var schedulerMapped = _mapper.Map<IEnumerable<Scheduler>, IEnumerable<SchedulerResponseDto>>(result.ToList());
                return Ok(schedulerMapped);
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


        [HttpGet("List/Executive/{executiveId}")]
        public ActionResult<List<SchedulerResponseDto>> ListScheduler(DefaultRequestDto request, long executiveId)
        {
            try
            {
                var userToken = Tools.TokenGetUser(Request);
                if (userToken.Type == 2)
                {
                    throw new ExceptionControlled("You are not authorized to see the classmate's schedule ", false, false);
                }

                request.QtyByPage = request.QtyByPage == 0 ? 99 : request.QtyByPage;
                request.Page = request.Page == 0 ? 1 : request.Page;
                request.Skip = (request.Page - 1) * request.QtyByPage;

                var query = _context.Schedulers
                    .Where(o => o.CompanyId == userToken.Company && !o.Deleted && o.UserId == executiveId && o.DateInitial >= DateTime.Now.AddMonths(-2))
                    .OrderByDescending(o => o.DateInitial);
                int totalList = query.Count();
                var result = query.Skip(request.Skip).Take(request.QtyByPage);
                double totalPage = Math.Ceiling(totalList / (double)request.QtyByPage);
                var schedulerMapped = _mapper.Map<IEnumerable<Scheduler>, IEnumerable<SchedulerResponseDto>>(result.ToList());
                return Ok(schedulerMapped);
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


        [HttpPut("{schedulerId}")]
        public async Task<ActionResult> Update(long schedulerId, SchedulerRequestDto request)
        {
            try
            {
                var scheduler = _context.Schedulers.Where(o => o.Id == schedulerId).FirstOrDefault();

                if (scheduler == null) throw new ExceptionControlled("Scheduler not found", false, false);

                if (request.DateInitial != null) scheduler.DateInitial = request.DateInitial;
                if (request.DateEnd != null) scheduler.DateEnd = request.DateEnd;
                if (request.Subject != null) scheduler.Subject = request.Subject;
                if (request.Description != null) scheduler.Description = request.Description;
                if (request.Contact != null) scheduler.Contact = request.Contact;
                if (request.PhoneContact != null) scheduler.PhoneContact = request.PhoneContact;
                if (request.Address != null) scheduler.Address = request.Address;
                if (request.Number != null) scheduler.Number = request.Number;
                if (request.Distric != null) scheduler.Distric = request.Distric;
                if (request.City != null) scheduler.City = request.City;
                if (request.State != null) scheduler.State = request.State;
                if (request.UF != null) scheduler.UF = request.UF;

                _context.Update(scheduler);
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


        [HttpDelete("{schedulerId}")]
        public async Task<ActionResult> Delete(long schedulerId)
        {
            try
            {
                var scheduler = _context.Schedulers.Where(o => o.Id == schedulerId).FirstOrDefault();

                if (scheduler == null)
                {
                    throw new ExceptionControlled("Scheduler not found", false, false);
                }
                _context.Remove(scheduler);
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