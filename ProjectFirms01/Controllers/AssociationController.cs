using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;

namespace ProjectFirms01.Controllers
{
    public class AssociationController : Controller
    {
        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        MngInfo mobj = new MngInfo();
        // GET: Association
        public ActionResult Index()
        {
            List<MdlAssociation> modellist = new List<MdlAssociation>();
            MngInfo obj = new MngInfo();
            modellist = obj.GetAllAssociationsofOrg(Convert.ToInt64(TempData["td_orgid"]));
            return View(modellist);
        }


        public ActionResult Create()
        {
            MdlAssociation model = new MdlAssociation();
            MngInfo ObjApp = new MngInfo();
            model.GetAllOrg_ID = ObjApp.GetAllOrgIDNName(0);
            //model.GetRenewalReport_ID = ObjApp.GetRenewalReportsofOrg();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MdlAssociation objform)
        {
            MdlAssociation model = new MdlAssociation();
            MngInfo ObjApp = new MngInfo();
            if (sig != null)
            {
                try
                {
                    objform.EnteredByUser_ID = sig.UserID;
                    ObjApp.AddNewAssociationofOrg(objform);
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
            MdlAssociation obj = new MdlAssociation();
            if (sig != null)
            {
                obj = mobj.GetAssociationtoEdit(id);
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
        public ActionResult Edit(MdlAssociation Wmodel)
        {
            if (sig != null)
            {
                try
                {
                    // TODO: Add update logic here
                    Wmodel.ModifyByUser_ID = sig.UserID;
                    mobj.UpdateAssociationofOrg(Wmodel);
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