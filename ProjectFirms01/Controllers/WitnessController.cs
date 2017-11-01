using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFirms01.Controllers
{
    public class WitnessController : Controller
    {
        // GET: Witness
        MdlWitness obj = new MdlWitness();
        List<MdlWitness> Lobj = new List<MdlWitness>();
        MngWitness mobj = new MngWitness();
        MngADDRESSS MobjAddress = new MngADDRESSS();
        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        public ActionResult Index()
        {
             if (sig != null)
            {
            Lobj = mobj.GetAllWitnessList();

            return View(Lobj);
            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }

        // GET: Witness/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Witness/Create
        public ActionResult Create(string Flag)
        {
             if (sig != null)
            {
            if (Flag == "SideBar")
            {
                UtilityClass.NullSession(UtilityClass.UserSession.OrgDocId, null);
            }

            obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocId(0);
            return View(obj);
            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }


        // POST: Witness/Create
        [HttpPost]
        public ActionResult Create(MdlWitness obj)
        {
              if (sig != null)
            {
            try
            {
                // TODO: Add insert logic here
                obj.EnterByUser_ID = sig.UserID;
                mobj.AddNewWitness(obj);
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

        // GET: Witness/Edit/5
        public ActionResult Edit(long id)
        {  if (sig != null)
            {
            obj = mobj.GetWitnessInfoForEdit(id);
            obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocId(obj.OrgDoc_ID);
            return View(obj);
             }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }

        // POST: Witness/Edit/5
        [HttpPost]
        public ActionResult Edit(MdlWitness Wmodel)
        {
            if (sig != null)
            {
            try
            {
                // TODO: Add update logic here
                Wmodel.EnterByUser_ID = sig.UserID;
                mobj.UpdateWitness(Wmodel);
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

        // GET: Witness/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Witness/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        [HttpGet]
        public ActionResult ListOfWitness(long Id)
        {
            //List<MdlPartner> model = new List<MdlPartner>();

            var sig = UtilityClass.GetOrgDocIdSession(UtilityClass.UserSession.OrgDocId);
            long ID;
            if (sig != null)
            {
                ID = Convert.ToInt32(sig.OrgDocID.ToString());
                Lobj = mobj.OrgWitnessList(ID);
            }
            else
            {
                ID = Id;
                Lobj = mobj.OrgWitnessList(ID);
            }
            return PartialView("~/Views/Witness/PartialViews/_OrgWitnessList.cshtml", Lobj);
        }




        #region madrassa

        public ActionResult MadrassaWitnessList()
        {
            if (sig != null)
            {
            Lobj = mobj.GetAllWitnessListForMadrassa();

            return View(Lobj);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        // GET: Witness/Create
        public ActionResult CreateMadrassaWitness(string Flag)
        {
             if (sig != null)
            {
            if (Flag == "SideBar")
            {
                UtilityClass.NullSession(UtilityClass.UserSession.OrgDocId, null);
            }

            obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocIdForMadrassa(0);
            return View(obj);
            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }


        // POST: Witness/Create
        [HttpPost]
        public ActionResult CreateMadrassaWitness(MdlWitness obj)
        {
               if (sig != null)
            {
            try
            {
                // TODO: Add insert logic here
                obj.EnterByUser_ID = sig.UserID;
                mobj.AddNewWitness(obj);
                return RedirectToAction("MadrassaWitnessList");

            }
            catch
            {
                obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocIdForMadrassa(0);
                return View(obj);
            }
            }
               else
               {
                   return RedirectToAction("Index", "Login");
               }
        }


        #endregion

        #region NGO/Society



        public ActionResult SocietyWitnessList()
        {
              if (sig != null)
            {
            Lobj = mobj.GetAllWitnessListForSociety();

            return View(Lobj);
            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }
        // GET: Witness/Create
        public ActionResult CreateSocietyWitness(string Flag)
        {
              if (sig != null)
            {
            if (Flag == "SideBar")
            {
                UtilityClass.NullSession(UtilityClass.UserSession.OrgDocId, null);
            }

            obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocIdForSocietyNGO(0);
            return View(obj);
            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }


        // POST: Witness/Create
        [HttpPost]
        public ActionResult CreateSocietyWitness(MdlWitness obj)
        { if (sig != null)
            {
            try
            {
                // TODO: Add insert logic here
                obj.EnterByUser_ID = sig.UserID;
                mobj.AddNewWitness(obj);
                return RedirectToAction("SocietyWitnessList");

            }
            catch
            {
                obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocIdForSocietyNGO(0);
                return View(obj);
            }
            }
        else
        {
            return RedirectToAction("Index", "Login");
        }
        }

        #endregion
    }
}
