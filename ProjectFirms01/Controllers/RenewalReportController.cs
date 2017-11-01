using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFirms01.Controllers
{
    public class RenewalReportController : Controller
    {
        // GET: RenewalReport
        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        public ActionResult Index()
        {
            List<MdlRenewalReport> modelList = new List<MdlRenewalReport>();
            MngRenewalReport ObjApp = new MngRenewalReport();
            modelList = ObjApp.GetAllRenewalReport(Convert.ToInt64(TempData["td_orgid"]));
            return View(modelList);
        }

        public ActionResult Create()
        {
            MdlRenewalReport model = new MdlRenewalReport();
            MngRenewalReport ObjApp=new MngRenewalReport();
            model.GetAllOrg_ID = ObjApp.GetAllOrgDocIdForSocietyNGO(0);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(MdlRenewalReport objform)
        {
            MdlRenewalReport model = new MdlRenewalReport();
            MngRenewalReport ObjApp = new MngRenewalReport();
            if (sig != null)
            {
                try
                {                   
                    objform.EnterByUser_ID = sig.UserID;
                    ObjApp.AddNewRenewalReport(objform);
                    TempData["td_orgid"] = objform.Org_ID;
                    return RedirectToAction("Index");
                }
                catch
                {         
                  
                    model.GetAllOrg_ID = ObjApp.GetAllOrgDocIdForSocietyNGO(0);
                    return View(model);

                }

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}