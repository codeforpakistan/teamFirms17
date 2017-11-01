using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;
using Rotativa.MVC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFirms01.Controllers
{
    public class FirmController : Controller
    {
        // GET: Firm
        public ActionResult Index()
        {
            var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
            if (sig != null)
            {
                List<MdlFirm> obj = new List<MdlFirm>();
                MngFirm mobj = new MngFirm();
                obj = mobj.GetAllFirms();
                return View(obj);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Details(string id)
        {

            string FileNo = id.Replace("-", "/");

            MngPDFReport Applogic = new MngPDFReport();
            FirmsBaseModel model = new FirmsBaseModel();

            model.addresslist = Applogic.GetAddressesofOrgnaizationUsingFileNo(FileNo);
           model.firmsinfomdl = Applogic.GetOrganizationNameUsingFileNo(FileNo);
            model.partnerlist = Applogic.GetPartnersofOrganizationUsingFileNo(FileNo);
            model.witnesslist = Applogic.GetWitnessesofOrganizationUsingFileNo(FileNo);

            return new ViewAsPdf("~/Views/Firm/Details.cshtml",model);
 
        }

        // GET: Firm/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}
        // GET: Firm/Create
        public ActionResult Create()
        {
            var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
            if (sig != null)
            {
                MdlFirm Fmodel = new MdlFirm();
                MngFirm mobj = new MngFirm();
                Fmodel.BankDistrictList = mobj.GetAllDistrics();
                Fmodel.GetAllBankList = mobj.GetAllBanks(0);
                return View(Fmodel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Test()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GETTEST()
        {

            List<Dropdownlist> objmodel = new List<Dropdownlist>();
            MngFirm mobj = new MngFirm();
            objmodel = mobj.GetAllBusinessType();
            return Json(objmodel, JsonRequestBehavior.AllowGet);

        }

        // POST: Firm/Create
        [HttpPost]
        public ActionResult Create(MdlFirm obj)
        {
            var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);

            if (sig != null)
            {

                try
                {
                    string[] strs = obj.BusinessType_IDstring.Split(',');
                    ArrayList al = new ArrayList();
                    al.AddRange(strs);
                    obj.BussinessTypeArry = strs;
                    obj.EnterByUser_ID = sig.UserID;
                    MngFirm mobj = new MngFirm();
                    MdlFirm FSmodel = new MdlFirm();
                    FSmodel = mobj.AddOldFirmData(obj);
                    UtilityClass.AddSession(UtilityClass.UserSession.OrgDocId, FSmodel);//Passing Firm Session Model                
                    return RedirectToAction("Create", "Addresss");
                }
                catch
                {
                    //TempData["message"] = ex.InnerException.Message.ToString();
                    MdlFirm Fmodel = new MdlFirm();
                    MngFirm mobj = new MngFirm();
                    Fmodel.BankDistrictList = mobj.GetAllDistrics();
                    return View(Fmodel);

                }

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult GETBussinessTypeinDD()
        {

            List<Dropdownlist> objmodel = new List<Dropdownlist>();
            MngFirm mobj = new MngFirm();
            objmodel = mobj.GetAllBusinessType();
            return Json(objmodel, JsonRequestBehavior.AllowGet);

        }
        // GET: Firm/Edit/5
        public ActionResult Edit(long id)
        {
             var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);

            if (sig != null)
            {
            MngFirm mobj = new MngFirm();
            MdlFirm FSmodel = new MdlFirm();
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
        public ActionResult Edit(MdlFirm FSmodel)
        {
              var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);

            if (sig != null)
            {
            try
            {
                MngFirm mobj = new MngFirm();
                FSmodel.EnterByUser_ID =sig.UserID;
                FSmodel.OrgType_ID = 1;
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

        // GET: Firm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Firm/Delete/5
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




        public ActionResult FormB()
        {
              var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);

            if (sig != null)
            {
            MdlFirm Fmodel = new MdlFirm();
            MngFirm mobj = new MngFirm();
            Fmodel.GetAllOrgDocId = mobj.GetAllOrgDocId(0);
            // Fmodel.BankDistrictList = mobj.GetAllDistrics();
            return View(Fmodel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult FormB(MdlFirm obj)
        {
               var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);

            if (sig != null)
            {
            try
            {
                obj.EnterByUser_ID =sig.UserID;
                MngFirm mobj = new MngFirm();
                MdlFirm FSmodel = new MdlFirm();
                FSmodel = mobj.InsertFormBAlterName(obj);
                //  UtilityClass.AddSession(UtilityClass.UserSession.OrgDocId, FSmodel);//Passing Firm Session Model                
                return RedirectToAction("Index");
            }
            catch
            {
                MdlFirm Fmodel = new MdlFirm();
                MngFirm mobj = new MngFirm();
                Fmodel.GetAllOrgDocId = mobj.GetAllOrgDocId(0);
                return View(Fmodel);

            }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult FormE()
        {
              var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);

            if (sig != null)
            {
            MdlPartner Pmodel = new MdlPartner();
            MngFirm mobj = new MngFirm();
            Pmodel.GetAllOrgId = mobj.GetAllOrgDocId(0);
            return View(Pmodel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        [HttpPost]
        public ActionResult FormE(MdlPartner model)
        {
            
              var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);

            if (sig != null)
            {
            try
            {
                model.EnterByUser_ID = sig.UserID;
                MngFirm mobj = new MngFirm();
                MdlPartner Pmodel = new MdlPartner();

                long ID = mobj.InsertFormEinfo(model);
                MdlFirm Fmodel = new MdlFirm();
                Fmodel.OrgDocID = ID;
                UtilityClass.AddSession(UtilityClass.UserSession.OrgDocId, Fmodel);//Passing Orgdocid to partner Session Model                
                return RedirectToAction("FormEPartner", "Partner");
            }
            catch
            {
                MdlPartner Pmodel = new MdlPartner();
                MngFirm mobj = new MngFirm();
                Pmodel.GetAllOrgId = mobj.GetAllOrgDocId(0);
                return View(Pmodel);

            }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult NewFormE()
        {
            var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);

            if (sig != null)
            {
                MdlPartner Pmodel = new MdlPartner();
                MngFirm mobj = new MngFirm();
                Pmodel.GetAllOrgId = mobj.GetAllOrgDocId(0);
                return View(Pmodel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult NewFormE(MdlPartner model)
        {

            var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);

            if (sig != null)
            {
                try
                {
                    model.EnterByUser_ID = sig.UserID;
                    MngFirm mobj = new MngFirm();
                    MdlPartner Pmodel = new MdlPartner();

                       MdlFirm Fmodel = new MdlFirm();

                       Fmodel = mobj.InsertNewFormEinfo(model); 

                    //long ID = mobj.InsertFormEinfo(model);
                    //MdlFirm Fmodel = new MdlFirm();
                    //Fmodel.OrgDocID = ID;
                    UtilityClass.AddSession(UtilityClass.UserSession.OrgDocId, Fmodel);
                    //Passing Orgdocid to partner Session Model                
                    return RedirectToAction("NewFormEIndex", "Partner");
                }
                catch(Exception ex)
                {

                    MdlPartner Pmodel = new MdlPartner();
                    MngFirm mobj = new MngFirm();
                    Pmodel.GetAllOrgId = mobj.GetAllOrgDocId(0);
                    return View(Pmodel);

                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult DeactivatePartner()
        {
            MdlPartner Pmodel = new MdlPartner();
            MngFirm mobj = new MngFirm();
            Pmodel.GetAllOrgId = mobj.GetAllOrgDocId(0);
            return PartialView("~/Views/Firm/PartialViews/_Deativepartner.cshtml", Pmodel);
        }

        [HttpPost]
        public ActionResult DeactivatePartner(long ID)
        {
            var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
            if (sig != null)
            {

            string message = string.Empty, status = string.Empty;
            try
            {
                MdlPartner Pmodel = new MdlPartner();
                MngFirm mobj = new MngFirm();
                Pmodel.EnterByUser_ID =sig.UserID;
                Pmodel.OrgId = Convert.ToInt64(ID.ToString());
                Pmodel = mobj.DeactivatePartner(Pmodel);

                UtilityClass.AddPartnerSession(UtilityClass.UserSession.OrgIdforpartner, Pmodel);
                message = BusinessLayer.MdlClasses.UtilityClass.UtilityMessages.updatemessage.ToString().Replace("Record", "Partner Info");
                status = BusinessLayer.MdlClasses.UtilityClass.Enums.ErrorClass.success.ToString();
            }
            catch (Exception ex)
            {
                message = BusinessLayer.MdlClasses.UtilityClass.UtilityMessages.errormessage.ToString();
                status = BusinessLayer.MdlClasses.UtilityClass.Enums.ErrorClass.error.ToString();
            }

            return Json(new { status = status.ToString(), message = message.ToString() });

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult UndoDeActivePartner(long ID)
        {
            // var sig = UtilityClass.GetSession(UserSession.ESSSession);
            string message = string.Empty, status = string.Empty;
            try
            {
                MdlPartner Pmodel = new MdlPartner();
                MngFirm mobj = new MngFirm();

                mobj.UndoDeactivePartner(ID);
                UtilityClass.NullSession(UtilityClass.UserSession.OrgIdforpartner, null);
                message = BusinessLayer.MdlClasses.UtilityClass.UtilityMessages.updatemessage.ToString();
                status = BusinessLayer.MdlClasses.UtilityClass.Enums.ErrorClass.success.ToString();
            }
            catch (Exception ex)
            {
                message = BusinessLayer.MdlClasses.UtilityClass.UtilityMessages.errormessage.ToString();
                status = BusinessLayer.MdlClasses.UtilityClass.Enums.ErrorClass.error.ToString();
            }
            return Json(new { status = status.ToString(), message = message.ToString() });
        }




    }
}
