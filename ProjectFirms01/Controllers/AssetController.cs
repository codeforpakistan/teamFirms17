using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;

namespace ProjectFirms01.Controllers
{
    public class AssetController : Controller
    {
        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        MngInfo mobj;
        // GET: Asset
        public ActionResult Index()
        {
            List<MdlAsset> modellist = new List<MdlAsset>();
            MngInfo obj = new MngInfo();
            modellist = obj.GetAllAssetsofOrg(Convert.ToInt64(TempData["td_orgid"]));
            return View(modellist);
        }


        public ActionResult Create()
        {
            MdlAsset model = new MdlAsset();
            MngInfo ObjApp = new MngInfo();
            model.GetAllOrg_ID = ObjApp.GetAllOrgIDNName(0);
            //model.GetRenewalReport_ID = ObjApp.GetRenewalReportsofOrg();
            return View(model);
        }

       [HttpPost]
        public ActionResult Create(MdlAsset objform)
        {
            MdlAsset model = new MdlAsset();
            MngInfo ObjApp = new MngInfo();
            if (sig != null)
            {
                try
                {
                    objform.EnterByUser_ID = sig.UserID;
                    ObjApp.AddNewAssetofOrg(objform);
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
            MdlAsset obj = new MdlAsset();
            mobj = new MngInfo();
            if (sig != null)
            {
                obj = mobj.GetAssettoEdit(id);
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
        public ActionResult Edit(MdlAsset Wmodel)
        {
            if (sig != null)
            {
                try
                {
                    // TODO: Add update logic here
                    mobj = new MngInfo();
                    Wmodel.ModifyByUser_ID = sig.UserID;
                    mobj.UpdateAssetofOrg(Wmodel);
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