using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFirms01.Controllers
{
    
    public class OrgTypeController : Controller
    {
        MngOrgType MngOrgTypeobj = new MngOrgType();
        // GET: OrgTyep
        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);

        public ActionResult Index()
        {
             if (sig != null)
            {
            List<MdlOrgType> listorgtypes = new List<MdlOrgType>();
            listorgtypes = MngOrgTypeobj.GetAllOrgTypes();

            return View(listorgtypes);
            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }

        public ActionResult Create()
        {
             if (sig != null)
            {
            MdlOrgType model = new MdlOrgType();
            return View(model);
            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }

        }
        [HttpPost]
        public ActionResult Create(MdlOrgType obj)
        { if (sig != null)
            {
            //MdlOrgType model = new MdlOrgType();
           // MngOrgType bznsorgtype = new MngOrgType();
                obj.EnteredByUser_ID = sig.UserID;
            MngOrgTypeobj.AddNewOrgType(obj);
            return RedirectToAction("Index");
            }
        else
        {
            return RedirectToAction("Index", "Login");
        }

        }
        public ActionResult Edit(int id)
        {
            if (sig != null)
            {
            MdlOrgType model = new MdlOrgType();

          model=MngOrgTypeobj.EditOrgType(id);
            return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        public ActionResult Edit(MdlOrgType obj)
        { 
             if (sig != null)
            {
                obj.EnteredByUser_ID = sig.UserID;
            MngOrgTypeobj.UpdateOrgType(obj);
            return RedirectToAction("Index");
            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }

        }
    }
}