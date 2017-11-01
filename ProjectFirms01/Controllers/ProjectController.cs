using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;

namespace ProjectFirms01.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        MngInfo mobj = new MngInfo();

        public ActionResult Index()
        {
            List<MdlProject> modellist = new List<MdlProject>();
            MngInfo obj = new MngInfo();
            modellist = obj.GetAllProjectsofOrg(Convert.ToInt64(TempData["td_orgid"]));
            return View(modellist);
        }

        public ActionResult Create()
        {
            MdlProject model = new MdlProject();
            MngInfo ObjApp = new MngInfo();
            model.GetAllOrg_ID = ObjApp.GetAllOrgIDNName(0);           
            //model.GetRenewalReport_ID = ObjApp.GetRenewalReportsofOrg();
            return View(model);
        }

        // POST: Witness/Edit/5
        [HttpPost]
        public ActionResult Create(MdlProject objform)
        {
            MdlProject model = new MdlProject();
            MngInfo ObjApp = new MngInfo();
            if (sig != null)
            {
                try
                {
                    objform.EnteredByUser_ID = sig.UserID;
                    ObjApp.AddNewSProjectofOrg(objform);
                    TempData["td_orgid"] = objform.Org_ID;
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

        public ActionResult Edit(long id)
        {
            MdlProject obj = new MdlProject();
            if (sig != null)
            {
                obj = mobj.GetProjecttoEdit(id);
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
        public ActionResult Edit(MdlProject Wmodel)
        {
            if (sig != null)
            {
                try
                {
                    // TODO: Add update logic here
                    Wmodel.ModifyByUser_ID = sig.UserID;
                    mobj.UpdateProjectofOrg(Wmodel);
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