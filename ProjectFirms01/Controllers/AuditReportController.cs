using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;

namespace ProjectFirms01.Controllers
{
    public class AuditReportController : Controller
    {
        // GET: AuditReport
        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);

        public ActionResult Index()
        {
            List<MdlAuditReport> modellist = new List<MdlAuditReport>();
            MngAuditReport obj = new MngAuditReport();
            modellist = obj.GetAllAuditReportsofRenewalReport(Convert.ToInt64(TempData["td_orgid"]));
            return View(modellist);
        }


        public ActionResult Create()
        {
            MdlAuditReport model = new MdlAuditReport();
            MngAuditReport ObjApp = new MngAuditReport();
            model.GetAllOrg_ID = ObjApp.GetAllOrgIDNName(0);
            //model.GetRenewalReport_ID = ObjApp.GetRenewalReportsofOrg();
            return View(model);
        }

        public JsonResult GetRenewalReport(int ID)
        {
            MdlAuditReport model = new MdlAuditReport();
            MngRenewalReport ObjApp = new MngRenewalReport();
            List<Dropdownlist> list = new List<Dropdownlist>();
            list = ObjApp.GetAllRenewalReportsofOrg(ID);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(MdlAuditReport objform)
        {
            MdlAuditReport model = new MdlAuditReport();
            MngAuditReport ObjApp = new MngAuditReport();
            if (sig != null)
            {
                try
                {
                    objform.EnteredByUser_ID = sig.UserID;
                    ObjApp.AddNewAuditReport(objform);
                    TempData["td_orgid"] = objform.RenewalReport_ID;
                    return RedirectToAction("Index");
                }
                catch
                {

                    model.GetAllOrg_ID = ObjApp.GetAllOrgIDNName(0);
                    //model.GetRenewalReport_ID = ObjApp.GetRenewalReportsofOrg();
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