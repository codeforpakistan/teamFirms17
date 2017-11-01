using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFirms01.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartnerInfo()
        {
            return View();
        }

        public ActionResult SearchPartnerOrg()
        {
            return View();
        }

        public ActionResult FirmDetails()
        {
            return View();
        }

        public ActionResult SocietyNGODetails()
        {
            return View();
        }

        public ActionResult MadrassaDetails()
        {
            return View();
        }

        public ActionResult OrgRegBwDates()
        {
            return View();
        }

        public ActionResult RegOrgCount()
        {
            return View();
        }
    }
}