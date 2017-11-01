using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFirms01.Controllers
{
    public class BusinessTypeController : Controller
    {
        // GET: BusinessType
        public ActionResult Index()
        {
             var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        if (sig != null)
        {
            List<MdlBusinessType> listmdlbusnz = new List<MdlBusinessType>();
            MngBusinessType mobj = new MngBusinessType();
            listmdlbusnz =  mobj.GetAllBusinessTypes();
            return View(listmdlbusnz);
        }
        else
        {
            return RedirectToAction("Index", "Login");
        }
        }

        public ActionResult Index1()
        {
            List<MdlBusinessType> listmdlbusnz = new List<MdlBusinessType>();
            MngBusinessType mobj = new MngBusinessType();
            listmdlbusnz = mobj.GetAllBusinessTypes();
            return View(listmdlbusnz);
        }

        public ActionResult Create()
        {
            var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        if (sig != null)
        {
             MngBusinessType mobj = new MngBusinessType();
               
            MdlBusinessType model = new MdlBusinessType();
            model.AllOrgTypes = mobj.AllOrgTypes(0);
            return View(model);
        }
        else
        {
            return RedirectToAction("Index", "Login");
        }
        }

        [HttpPost]
        public ActionResult Create(MdlBusinessType obj)
        {var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        if (sig != null)
        {
            try
            {

                MngBusinessType mobj = new MngBusinessType();
                obj.EnteredByUser_ID = sig.UserID;
                mobj.AddNewBusinessType(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                MdlBusinessType model = new MdlBusinessType();
                return View(model);
            }
        }
        else
        {
            return RedirectToAction("Index", "Login");
        }
        }



        public ActionResult Edit(int ID)
        {
            var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
            if (sig != null)
            {
                MngBusinessType mobj = new MngBusinessType();

                MdlBusinessType model = new MdlBusinessType();
                model = mobj.EditBussinessType(ID);
                model.AllOrgTypes = mobj.AllOrgTypes(model.OrgTypeID);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult Edit(MdlBusinessType obj)
        {
            var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
            if (sig != null)
            {
                try
                {

                    MngBusinessType mobj = new MngBusinessType();
                    obj.EnteredByUser_ID = sig.UserID;

                    if(obj.Status=="on")
                    {
                        obj.IsActive = true;
                    }
                    else
                    {
                        obj.IsActive = false;
                    }
                    mobj.UpdateBussinessTyep(obj);
                    return RedirectToAction("Index");
                }
                catch
                {
                    MdlBusinessType model = new MdlBusinessType();
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