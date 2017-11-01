using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;

namespace ProjectFirms01.Controllers
{
    public class BankAccountController : Controller
    {
        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        MngInfo mobj = new MngInfo();


        // GET: BankAccount
        public ActionResult Index()
        {
            List<MdlBankAccount> modellist = new List<MdlBankAccount>();
            MngInfo obj = new MngInfo();
            modellist = obj.GetAllBankAccountsofOrg(Convert.ToInt64(TempData["td_orgid"]));
            return View(modellist);

        }

        public ActionResult Create()
        {
            MdlBankAccount model = new MdlBankAccount();
            MngInfo ObjApp = new MngInfo();
            model.GetAllOrg_ID = ObjApp.GetAllOrgIDNName(0);
            model.GetAllBank_ID = ObjApp.GetAllBankIDNNames(0);
            //model.GetRenewalReport_ID = ObjApp.GetRenewalReportsofOrg();
            return View(model);
        }

        // POST: Witness/Edit/5
        [HttpPost]
        public ActionResult Create(MdlBankAccount objform)
        {
            MdlBankAccount model = new MdlBankAccount();
            MngInfo ObjApp = new MngInfo();
            if (sig != null)
            {
                try
                {
                    objform.EnteredByUser_ID = sig.UserID;
                    ObjApp.AddNewBankAcctofOrg(objform);
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
            MdlBankAccount obj = new MdlBankAccount();
            if (sig != null)
            {
                obj = mobj.GetBankAccounttoEdit(id);
                obj.GetAllOrg_ID = mobj.GetAllOrgIDNName(obj.Org_ID);
                obj.GetAllBank_ID = mobj.GetAllBankIDNNames(obj.Bank_ID);
                return View(obj);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Witness/Edit/5
        [HttpPost]
        public ActionResult Edit(MdlBankAccount Wmodel)
        {
            if (sig != null)
            {
                try
                {
                    // TODO: Add update logic here
                    Wmodel.ModifyByUser_ID = sig.UserID;
                    mobj.UpdateBankAccount(Wmodel);
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