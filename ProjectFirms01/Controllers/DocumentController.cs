using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFirms01.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        public ActionResult Index()
        {
             if (sig != null)
            {
            MngDocument mobj = new MngDocument();            
            return View(mobj.GetAllDocuments());
            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }

        // GET: Document/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Document/Create
        public ActionResult Create()
        {  if (sig != null)
            {
            MdlDocument obj = new MdlDocument();
            return View(obj);
            }
        else
        {
            return RedirectToAction("Index", "Login");
        }
        }

        // POST: Document/Create
        [HttpPost]
        public ActionResult Create(MdlDocument obj)
        {
            if (sig != null)
            {
                try
                {
                    // TODO: Add insert logic here                
                    MngDocument mobj = new MngDocument();
                    mobj.AddNewDocument(obj);
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

        // GET: Document/Edit/5
        public ActionResult Edit(int id)
        {
              if (sig != null)
            {
            MngDocument mobj = new MngDocument();
             MdlDocument obj=new MdlDocument();
           obj= mobj.EditDocument(id);
            
            return View(obj);
            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }

        // POST: Document/Edit/5
        [HttpPost]
        public ActionResult Edit(MdlDocument obj)
        {
              if (sig != null)
            {
            try
            {
                // TODO: Add update logic here
                MngDocument mobj = new MngDocument();
                mobj.UpdateDocument(obj);
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

        // GET: Document/Delete/5
        public ActionResult Delete(int id)
        {
              if (sig != null)
            {
            MngDocument mobj = new MngDocument();
            MdlDocument obj = new MdlDocument();
            obj = mobj.EditDocument(id);

            return View(obj);
            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }

        // POST: Document/Delete/5
        [HttpPost]
        public ActionResult Delete(MdlDocument obj)
        {
             if (sig != null)
            {
            try
            {

                // TODO: Add delete logic here

                MngDocument mobj = new MngDocument();
              //  int id = obj.DocumentID;
                mobj.DelteDocType(obj.DocumentID);
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
