using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;

namespace ProjectFirms01.Controllers
{
    public class FundController : Controller
    {
        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        MngInfo mobj = new MngInfo();
        // GET: Fund
        public ActionResult Index()
        {
            List<MdlFund> modellist = new List<MdlFund>();
            MngInfo obj = new MngInfo();
            modellist = obj.GetAllFundsofOrg(Convert.ToInt64(TempData["td_orgid"]));
            return View(modellist);
        }


        public ActionResult Create()
        {
            MdlFund model = new MdlFund();
            MngInfo ObjApp = new MngInfo();
            model.GetAllOrg_ID = ObjApp.GetAllOrgIDNName(0);
            //model.GetRenewalReport_ID = ObjApp.GetRenewalReportsofOrg();
            return View(model);
        }

    [HttpPost]
        public ActionResult Create(MdlFund objform)
        {
            MdlFund model = new MdlFund();
            MngInfo ObjApp = new MngInfo();
            if (sig != null)
            {
                try
                {
                    objform.EnteredByUser_ID = sig.UserID;
                    ObjApp.AddNewFundSourceofOrg(objform);
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
            MdlFund obj = new MdlFund();
            if (sig != null)
            {
                obj = mobj.GetFundtoEdit(id);
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
        public ActionResult Edit(MdlFund Wmodel)
        {
            if (sig != null)
            {
                try
                {
                    // TODO: Add update logic here
                    Wmodel.ModifyByUser_ID = sig.UserID;
                    mobj.UpdateFundSource(Wmodel);
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