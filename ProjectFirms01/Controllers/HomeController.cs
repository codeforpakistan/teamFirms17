using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFirms01.Controllers
{
    public class HomeController : Controller
    {

        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        public ActionResult Index()
        {
              if (sig != null)
            {

            return View();
            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }


        [HttpGet]
        public ActionResult GetCounttable()
        {
            //List<MdlPartner> model = new List<MdlPartner>();
          //  var sig = UtilityClass.GetOrgDocIdSession(UtilityClass.UserSession.OrgDocId);
            MngFirm objApp = new MngFirm();
         List<MdlCount> modellist=new List<MdlCount>();
         modellist = objApp.GetCount();
         return PartialView("~/Views/Home/_GetCounttable.cshtml", modellist);
        }

        public ActionResult Index2()
        {
            return View();
        }



     

        public ActionResult DataTable()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult Setups()
        {
              if (sig != null)
            {

            MngDistrictandTehsils objApp = new MngDistrictandTehsils();
            MdlDistrictandTehsils modellist = new MdlDistrictandTehsils();
            modellist.DistrictList = objApp.GetAllDistrictsList();
            modellist.TehsilList = objApp.GetAllTehsilList();
            

            return View(modellist);
            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }


        [HttpGet]
        public ActionResult CreateDistrictModle()
        {
           MdlDistrictandTehsils Pmodel = new MdlDistrictandTehsils();
          
            return PartialView("~/Views/Home/PartialViews/_CreateDistrictModle.cshtml", Pmodel);
        }

        [HttpGet]
        public ActionResult CreateTehsilsModle()
        {
            MdlDistrictandTehsils Pmodel = new MdlDistrictandTehsils();
            MngDistrictandTehsils ObjApp = new MngDistrictandTehsils();
            Pmodel.GetAllDistrictsDrp = ObjApp.GetAllDistrict(0);
            return PartialView("~/Views/Home/PartialViews/_CreateTehsilModel.cshtml", Pmodel);
        }


        [HttpGet]
        public ActionResult UpdateDistrictModle(int Id)
        {
            MdlDistrictandTehsils Pmodel = new MdlDistrictandTehsils();
            MngDistrictandTehsils mobj = new MngDistrictandTehsils();
           Pmodel= mobj.EditDistrict(Id);
            return PartialView("~/Views/Home/PartialViews/_CreateDistrictModle.cshtml", Pmodel);
        }

        [HttpGet]
        public ActionResult UpdateTeshilModle(int Id)
        {
            MdlDistrictandTehsils Pmodel = new MdlDistrictandTehsils();
            MngDistrictandTehsils ObjApp = new MngDistrictandTehsils();
            Pmodel = ObjApp.EditTehsil(Id);
            Pmodel.GetAllDistrictsDrp = ObjApp.GetAllDistrict(Pmodel.DistrictID);
            return PartialView("~/Views/Home/PartialViews/_CreateTehsilModel.cshtml", Pmodel);
        }

        [HttpPost]
        public ActionResult CreateDistrict(string DistName, int DistrictID)
        {
            // var sig = UtilityClass.GetSession(UserSession.ESSSession);
            string message = string.Empty, status = string.Empty;
            try
            {
                if (DistrictID == 0)
                {
                    MngDistrictandTehsils mobj = new MngDistrictandTehsils();
                    mobj.CreateDistrict(DistName);
                    message = BusinessLayer.MdlClasses.UtilityClass.UtilityMessages.successmessage.ToString();
                    status = BusinessLayer.MdlClasses.UtilityClass.Enums.ErrorClass.success.ToString();
                }
                else
                {
                    MngDistrictandTehsils mobj = new MngDistrictandTehsils();
                    mobj.UpdateDistrict(DistName,DistrictID);
                    message = BusinessLayer.MdlClasses.UtilityClass.UtilityMessages.updatemessage.ToString();
                    status = BusinessLayer.MdlClasses.UtilityClass.Enums.ErrorClass.success.ToString();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;// BusinessLayer.MdlClasses.UtilityClass.UtilityMessages.errormessage.ToString();
                status = BusinessLayer.MdlClasses.UtilityClass.Enums.ErrorClass.error.ToString();
            }
            return Json(new { status = status.ToString(), message = message.ToString() });
        }


        [HttpPost]
        public ActionResult CreateTehsil(string TehsilName, int DistrictID, int TehsilID)
        {
            // var sig = UtilityClass.GetSession(UserSession.ESSSession);
            string message = string.Empty, status = string.Empty;
            try
            {
                if (TehsilID == 0)
                {
                    MngDistrictandTehsils mobj = new MngDistrictandTehsils();
                    mobj.CreateTehsil(TehsilName, DistrictID);
                    message = BusinessLayer.MdlClasses.UtilityClass.UtilityMessages.successmessage.ToString();
                    status = BusinessLayer.MdlClasses.UtilityClass.Enums.ErrorClass.success.ToString();
                }
                else
                {
                    MngDistrictandTehsils mobj = new MngDistrictandTehsils();
                    mobj.UpdateTehsil(TehsilName, DistrictID,TehsilID);
                    message = BusinessLayer.MdlClasses.UtilityClass.UtilityMessages.updatemessage.ToString();
                    status = BusinessLayer.MdlClasses.UtilityClass.Enums.ErrorClass.success.ToString();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;// BusinessLayer.MdlClasses.UtilityClass.UtilityMessages.errormessage.ToString();
                status = BusinessLayer.MdlClasses.UtilityClass.Enums.ErrorClass.error.ToString();
            }
            return Json(new { status = status.ToString(), message = message.ToString() });
        } 
        
    }
}