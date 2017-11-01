using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;

namespace ProjectFirms01.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);

        public ActionResult BankAccountIndex()
        {
            return View();
        }

        public ActionResult AssocaitionIndex()
        {
            return View();
        }

        public ActionResult AssetIndex()
        {
            return View();
        }
        public ActionResult FundSourceIndex()
        {
            return View();
        }
        public ActionResult StaffIndex()
        {
            return View();
        }


    }
}