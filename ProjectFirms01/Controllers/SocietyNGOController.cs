using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFirms01.Controllers
{
    public class SocietyNGOController : Controller
    {
        // GET: SocietyNGO
        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        public ActionResult Index()
        {
             if (sig != null)
            {
            List<MdlSocietyNGO> obj = new List<MdlSocietyNGO>();
            MngSocietyNGO mobj = new MngSocietyNGO();
            obj = mobj.GetAllSocietyNGO();
            return View(obj);
            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
            
        }

        // GET: SocietyNGO/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SocietyNGO/Create
        // GET: Madrassa/Create
        public ActionResult Create()
        {   if (sig != null)
            {
            MdlSocietyNGO Smodel = new MdlSocietyNGO();
            MngSocietyNGO Sobj = new MngSocietyNGO();
            Smodel.BankDistrictList = Sobj.GetAllDistrics();
            Smodel.SocietyTypeDrp = Sobj.SocietyTypeDrp(0);
            Smodel.BanksList = Sobj.GetBankList(0);

            return View(Smodel);
            }
        else
        {
            return RedirectToAction("Index", "Login");
        }

        }
        [HttpPost]
        public ActionResult Create(MdlSocietyNGO obj)
        {if (sig != null)
            {
            try
            {
                obj.EnterByUser_ID =sig.UserID;
                MngSocietyNGO mobj = new MngSocietyNGO();
                MdlSocietyNGO Mmodel = new MdlSocietyNGO();
                MdlFirm Fmodel = new MdlFirm();
                Fmodel = mobj.AddSocietyNGO(obj);
                UtilityClass.AddSession(UtilityClass.UserSession.OrgDocId, Fmodel);//Passing Firm Session Model
                return RedirectToAction("CreateSocietyAddress", "Addresss");
            }
            catch
            {
                MdlSocietyNGO Smodel = new MdlSocietyNGO();
                MngSocietyNGO Sobj = new MngSocietyNGO();
                Smodel.BankDistrictList = Sobj.GetAllDistrics();
                Smodel.SocietyTypeDrp = Sobj.SocietyTypeDrp(0);
                Smodel.BanksList = Sobj.GetBankList(0);
                return View(Smodel);


            }
            }
        else
        {
            return RedirectToAction("Index", "Login");
        }
        }


        // GET: SocietyNGO/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SocietyNGO/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SocietyNGO/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SocietyNGO/Delete/5
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





        #region Resolution like formb
        public ActionResult Resolution()
        {
            if (sig != null)
            {
            MdlSocietyNGO Mmodel = new MdlSocietyNGO();
            MngSocietyNGO mobj = new MngSocietyNGO();
            Mmodel.GetAllOrgDocId = mobj.GetAllOrgDocIdForSocietyNGO(0);
            return View(Mmodel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult Resolution(MdlSocietyNGO obj)
        {
             if (sig != null)
            {
            try
            {
                obj.EnterByUser_ID =sig.UserID;
                MdlSocietyNGO Mmodel = new MdlSocietyNGO();
                MngSocietyNGO mobj = new MngSocietyNGO();
                Mmodel = mobj.InsertResolutionForAlterName(obj);
                //  UtilityClass.AddSession(UtilityClass.UserSession.OrgDocId, FSmodel);//Passing Firm Session Model                
                return RedirectToAction("Index");
            }
            catch
            {
                MdlSocietyNGO Mmodel = new MdlSocietyNGO();
                MngSocietyNGO mobj = new MngSocietyNGO();
                Mmodel.GetAllOrgDocId = mobj.GetAllOrgDocIdForSocietyNGO(0);
                return View(Mmodel);

            }
            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }

        #endregion


        #region Governing Body replace or change like Form E
        public ActionResult GoverningBodyAlteration(string Flag)
        {
             if (sig != null)
            {
            if (Flag == "SideBar")
            {
                UtilityClass.NullSession(UtilityClass.UserSession.OrgDocId, null);
            }
            MdlPartner Pmodel = new MdlPartner();
            MngFirm mobj = new MngFirm();
            Pmodel.GetAllOrgId = mobj.GetAllOrgDocIdForNGOSociety(0);
            return View(Pmodel);
            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }


        [HttpPost]
        public ActionResult GoverningBodyAlteration(MdlPartner model)
        {
               if (sig != null)
            {
            try
            {
                model.EnterByUser_ID =sig.UserID;
                MngFirm mobj = new MngFirm();
                MdlPartner Pmodel = new MdlPartner();
                MdlFirm Fmodel = new MdlFirm();
                Fmodel = mobj.InsertNGOSocietyFormEinfo(model);
                UtilityClass.AddSession(UtilityClass.UserSession.OrgDocId, Fmodel);//Passing Orgdocid to partner Session Model                
                return RedirectToAction("SocietyGoverningBodyAlterationList", "Partner");
            }
            catch
            {
                MdlPartner Pmodel = new MdlPartner();
                MngFirm mobj = new MngFirm();
                Pmodel.GetAllOrgId = mobj.GetAllOrgDocIdForNGOSociety(0);
                return View(Pmodel);

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
