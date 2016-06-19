using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testcore.Website.Models;

namespace Testcore.Website.Controllers
{
    public class SitecoreJobsController : Controller
    {
        // GET: SitecoreJobs
        public ActionResult GetJobs()
        {
            var result = new List<SCJob>();

            var scjobs = Sitecore.Jobs.JobManager.GetJobs().OrderBy(j => j.QueueTime);
            result.AddRange(scjobs.ToList().ConvertAll<SCJob>(s => new SCJob()
            {
                Name = s.Name,
                Status = s.Status.State.ToString(),
                QueueTime = s.QueueTime.ToString(),
                Category = s.Category
            }));
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}