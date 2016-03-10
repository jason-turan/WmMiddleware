using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Middleware.Jobs.Models;
using Middleware.Log;
using Middleware.Scheduler.Web.Service;

namespace Middleware.Scheduler.Web.Controllers
{
    public class JobsController : Controller
    {
        private readonly ILog _log;

        private readonly IJobService _jobService;

        public JobsController(ILog log, IJobService jobService)
        {
            _log = log;
            _jobService = jobService;
        }

        // GET: /Jobs/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Jobs/Index
        public JsonResult GetIndex()
        {
            try
            {
                return Json(_jobService.GetJobs().
                    OrderBy(a => a.JobKey), JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                _log.Exception(exception);
                throw;
            }
        }

        // POST: /Jobs/SaveJobSchedule
        [HttpPost]
        public ActionResult SaveJobSchedule(MiddlewareJob job)
        {
            if (!_jobService.SaveMiddlewareJobSchedule(job.JobKey, job.Schedule))
            {
                Response.StatusCode = (int) HttpStatusCode.ExpectationFailed;
            }

            return GetIndex();
        }

        // POST: /Jobs/SaveJobActiveStatus
        [HttpPost]
        public ActionResult SaveJobActiveStatus(MiddlewareJob job)
        {
            _jobService.SaveMiddlewareJobActiveStatus(job.JobKey, job.IsActive);
            return GetIndex();
        }

        // POST: /Jobs/LaunchJob
        [HttpPost]
        public ActionResult LaunchJob(MiddlewareJob job)
        {

            if (!_jobService.LaunchJob(job.JobKey, User.Identity.Name))
            {
                Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
            }
       
            return GetIndex();
        }
    }
}
