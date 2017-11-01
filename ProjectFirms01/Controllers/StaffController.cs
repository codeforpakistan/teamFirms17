using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;

namespace ProjectFirms01.Controllers
{
    public class StaffController : Controller
    {
        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        MngInfo mobj = new MngInfo();
        // GET: Staff
        public ActionResult Index()
        {
            List<MdlStaff> modellist = new List<MdlStaff>();
            MngInfo obj = new MngInfo();
            modellist = obj.GetAllStaffofOrg(Convert.ToInt64(TempData["td_orgid"]));
            return View(modellist);
        }


        public ActionResult Create()
        {
            MdlStaff model = new MdlStaff();
            MngInfo ObjApp = new MngInfo();
            model.GetAllOrg_ID = ObjApp.GetAllOrgIDNName(0);
            model.GetAllDesig_ID = ObjApp.GetAllDesignation(0);
            //model.GetRenewalReport_ID = ObjApp.GetRenewalReportsofOrg();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MdlStaff objform)
        {
            MdlStaff model = new MdlStaff();
            MngInfo ObjApp = new MngInfo();
            if (sig != null)
            {
                try
                {
                    objform.EnteredByUser_ID = sig.UserID;
                    ObjApp.AddNewStaffofOrg(objform);
                    TempData["td_orgid"] = objform.Org_ID;
                    return RedirectToAction("Index");
                }
                catch
                {

                    model.GetAllOrg_ID = ObjApp.GetAllOrgIDNName(0);
                    model.GetAllDesig_ID = ObjApp.GetAllDesignation(0);
                    //model.GetRenewalReport_ID = ObjApp.GetRenewalReportsofOrg();
                    return View(model);

                }

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Edit(long id)
        {
            MdlStaff obj = new MdlStaff();
            if (sig != null)
            {
                obj = mobj.GetStafftoEdit(id);
                obj.GetAllOrg_ID = mobj.GetAllOrgIDNName(obj.Org_ID);
                return View(obj);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Witness/Edit/5
        [HttpPost]
        public ActionResult Edit(MdlStaff Wmodel)
        {
            if (sig != null)
            {
                try
                {
                    // TODO: Add update logic here
                    Wmodel.ModifyByUser_ID = sig.UserID;
                    mobj.UpdateStaffofOrg(Wmodel);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}