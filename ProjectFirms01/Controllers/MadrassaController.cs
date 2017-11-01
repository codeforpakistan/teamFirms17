using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFirms01.Controllers
{
    public class MadrassaController : Controller
    {
        // GET: Madrassa
        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        public ActionResult Index()
        {
           // var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
            if (sig != null)
            {
            List<MdlMadrassa> obj = new List<MdlMadrassa>();
            MngMadrassa mobj = new MngMadrassa();
            obj = mobj.GetAllMadrassa();
            return View(obj);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Madrassa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Madrassa/Create
        public ActionResult Create()
        { if (sig != null)
            {
            MdlMadrassa Mmodel = new MdlMadrassa();
            MngMadrassa Mobj = new MngMadrassa();
            Mmodel.BankDistrictList = Mobj.GetAllDistrics();
            Mmodel.SectTypeDrp = Mobj.SectTypeDrp(0);
            Mmodel.BanksList = Mobj.GetBankList(0);
            return View(Mmodel);
            }
        else
        {
            return RedirectToAction("Index", "Login");
        }
        }
        [HttpPost]
        public ActionResult Create(MdlMadrassa obj)
        {
            if (sig != null)
            {
            try
            {

                obj.EnterByUser_ID = sig.UserID;
                MngMadrassa mobj = new MngMadrassa();
                MdlMadrassa Mmodel = new MdlMadrassa();
                MdlFirm FSmodel = new MdlFirm();
                FSmodel = mobj.AddMadrassaData(obj);    
                
                UtilityClass.AddSession(UtilityClass.UserSession.OrgDocId, FSmodel);//Passing Firm Session Model           
             //   UtilityClass.AddMadrassaSession(UtilityClass.UserSession.OrgDocId, Mmodel);//Passing Firm Session Model     
                return RedirectToAction("CreateMadrassaAddress", "Addresss");
                 
            }
            catch(Exception ex)
            {
                MdlMadrassa Mmodel = new MdlMadrassa();
                MngMadrassa Mobj = new MngMadrassa();
                Mmodel.BankDistrictList = Mobj.GetAllDistrics();
                Mmodel.SectTypeDrp = Mobj.SectTypeDrp(0);
                return View(Mmodel);
            

            }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult Edit(long id)
        {
              if (sig != null)
            {
            MngMadrassa mobj = new MngMadrassa();
            MdlMadrassa FSmodel = new MdlMadrassa();
            FSmodel = mobj.GetFirmDataForEdit(id);
            return View(FSmodel);
            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }

        // POST: Firm/Edit/5
        [HttpPost]
        public ActionResult Edit(MdlMadrassa FSmodel)
        {
             if (sig != null)
            {
            try
            {
                MngMadrassa mobj = new MngMadrassa();
                FSmodel.EnterByUser_ID =sig.UserID;
                FSmodel.OrgType_ID = 3;
                mobj.UpdateOldFirmData(FSmodel);

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

        // GET: Madrassa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Madrassa/Delete/5
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
            MdlMadrassa Mmodel = new MdlMadrassa();
            MngMadrassa mobj = new MngMadrassa();
            Mmodel.GetAllOrgDocId = mobj.GetAllOrgDocIdForMadrassa(0);
            return View(Mmodel);
            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }

        [HttpPost]
        public ActionResult Resolution(MdlMadrassa obj)
        { if (sig != null)
            {
            try
            {
                obj.EnterByUser_ID = sig.UserID;
                MdlMadrassa Mmodel = new MdlMadrassa();
                MngMadrassa mobj = new MngMadrassa();
                Mmodel = mobj.InsertResolutionForAlterName(obj);
                //  UtilityClass.AddSession(UtilityClass.UserSession.OrgDocId, FSmodel);//Passing Firm Session Model                
                return RedirectToAction("Index");
            }
            catch
            {
                MdlMadrassa Mmodel = new MdlMadrassa();
                MngMadrassa mobj = new MngMadrassa();
                Mmodel.GetAllOrgDocId = mobj.GetAllOrgDocIdForMadrassa(0);
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
            Pmodel.GetAllOrgId = mobj.GetAllOrgDocIdForMadrassa(0);
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
                model.EnterByUser_ID = sig.UserID;
                MngFirm mobj = new MngFirm();
                MdlPartner Pmodel = new MdlPartner();
                MdlFirm Fmodel = new MdlFirm();
                Fmodel = mobj.InsertMadrassaFormEinfo(model);   
                UtilityClass.AddSession(UtilityClass.UserSession.OrgDocId, Fmodel);//Passing Orgdocid to partner Session Model                
                return RedirectToAction("GoverningBodyAlterationList", "Partner");
            }
            catch
            {
                MdlPartner Pmodel = new MdlPartner();
                MngFirm mobj = new MngFirm();
                Pmodel.GetAllOrgId = mobj.GetAllOrgDocIdForMadrassa(0);
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
