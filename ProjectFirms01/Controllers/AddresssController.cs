using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProjectFirms01.Controllers
{
   

    public class AddresssController : Controller
    {
        // GET: Addresss
        MdlADDRESSS obj = new MdlADDRESSS();
        MngADDRESSS mobj = new MngADDRESSS();
        List<MdlADDRESSS> objList = new List<MdlADDRESSS>();
        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        public ActionResult Index()
        {
             if (sig != null)
            {
            objList = mobj.GetAllAddress(1);
            return View(objList);

            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }

 
      

        // GET: Addresss/Create
        public ActionResult Create(string Flag)
        {
              if (sig != null)
            {
            if (Flag == "SideBar")
            {
             UtilityClass.NullSession(UtilityClass.UserSession.OrgDocId, null);
            }
            //else
            //{
            //   UtilityClass.AddSession(UtilityClass.UserSession.OrgDocId,"10023");
            //}
            obj.DistricsDDL = mobj.GetAllDistrics(0);
            obj.AddressTypes = mobj.GetAllAddressType(0);
            obj.GetAllOrgDocId = mobj.GetAllOrgDocId(0);         
            return View(obj);

            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }


     
        //For testing dropdown change and fill through dataset for now not in use 
        public JsonResult GetTehsils1(int ID)
        {

           var list  = new List<Dropdownlist>();            
           var ds = mobj.GetTehsilsByDistricbyDataset(ID);
           
           foreach (DataRow dr in ds.Tables[0].Rows)
           {
               list.Add(new Dropdownlist
               {
                   Label = dr["Label"].ToString(),
                   Value =Convert.ToInt16(dr["Value"].ToString())
               });
           }
            return Json(list, JsonRequestBehavior.AllowGet);
        }


       // [HttpPost]
        public JsonResult GetTehsils(int ID, int Tehsil)
        {
            List<Dropdownlist> list = new List<Dropdownlist>();
            list = mobj.GetTehsilsByDistric(ID,Tehsil);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // POST: Addresss/Create
        [HttpPost]
        public ActionResult Create(MdlADDRESSS objform)
        {
            
              if (sig != null)
            {
            try
            {
                // TODO: Add insert logic here
                objform.EnterByUser_ID = sig.UserID;
                mobj.AddAddresss(objform);
                //TempData["foo1"] = "From Create";
                return RedirectToAction("Index");
            }
            catch
            {
                
                obj.DistricsDDL = mobj.GetAllDistrics(0);
                obj.AddressTypes = mobj.GetAllAddressType(0);
                obj.GetAllOrgDocId = mobj.GetAllOrgDocId(0);
                return View(obj);
               
            }

            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }

        // GET: Addresss/Edit/5
        public ActionResult Edit(int id)
        {  
            
              if (sig != null)
            {
            obj = mobj.EditADDRESSS(id);
            obj.DistricsDDL = mobj.GetAllDistrics(obj.Distric_ID);
            obj.AddressTypes = mobj.GetAllAddressType(obj.AdressType_ID);
            obj.GetAllOrgDocId = mobj.GetAllOrgDocId(obj.OrgDoc_ID);  
          
            return View(obj);

            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }

        // POST: Addresss/Edit/5
        [HttpPost]
        public ActionResult Edit(MdlADDRESSS objform)
        {
            
              if (sig != null)
            {
            try
            {
                // TODO: Add update logic here
                objform.ModifyByUser_ID = sig.UserID;
                mobj.UpdateAddress(objform);
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



     




        [HttpGet]
        public ActionResult ListOfAddress(long Id)
        {
            //List<MdlPartner> model = new List<MdlPartner>();
            var sig = UtilityClass.GetOrgDocIdSession(UtilityClass.UserSession.OrgDocId);
            long ID;
            if (sig != null)
            {
                ID = Convert.ToInt32(sig.OrgDocID.ToString());
                objList = mobj.OrgAddressList(ID);
            }
            else
            {
                ID = Id;
                objList = mobj.OrgAddressList(ID);
            }
            return PartialView("~/Views/Addresss/PartialViews/_OrgAddressList.cshtml", objList);
        }



      
        public ActionResult Details(int id)
        {
              
              if (sig != null)
            {
            obj = mobj.EditADDRESSS(id);
            return View(obj);

            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }
        // GET: Addresss/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Addresss/Delete/5
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





        #region Address Alter
        public ActionResult AddressAlter()
        {
                
              if (sig != null)
            {
            obj.GetAllOrgDocId = mobj.GetAllOrgDocIdForAlterAddress(0);
            obj.DistricsDDL = mobj.GetAllDistrics(0);
            obj.AddressTypes = mobj.GetAllAddressType(0);         
            return View(obj);

            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }

        [HttpPost]
        public ActionResult AddressAlter(MdlADDRESSS objform)
        {
                 
              if (sig != null)
            {
            try
            {
                // TODO: Add insert logic here
                objform.EnterByUser_ID = sig.UserID;
                mobj.InsertFormBAlterAddress(objform);
                //TempData["foo1"] = "From Create";
                return RedirectToAction("Index");
            }
            catch
            {
                obj.GetAllOrgDocId = mobj.GetAllOrgDocIdForAlterAddress(0);
                obj.DistricsDDL = mobj.GetAllDistrics(0);
                obj.AddressTypes = mobj.GetAllAddressType(0);
                return View(obj);
                
            }

            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }


        [HttpGet]
        public ActionResult ListOfAddressAlter(long Id)
        {
            //List<MdlPartner> model = new List<MdlPartner>();
            var sig = UtilityClass.GetOrgDocIdSession(UtilityClass.UserSession.OrgDocId);
            long ID;
            if (sig != null)
            {
                ID = Convert.ToInt32(sig.OrgDocID.ToString());
                objList = mobj.OrgAddressAlterList(ID);
            }
            else
            {
                ID = Id;
                objList = mobj.OrgAddressAlterList(ID);
            }
            return PartialView("~/Views/Addresss/PartialViews/_OrgAddressForAlter.cshtml", objList);
        }







        #endregion



        #region Madrassa
        public ActionResult CreateMadrassaAddress(string Flag)
        {
             if (sig != null)
            {
            if (Flag == "SideBar")
            {
                UtilityClass.NullSession(UtilityClass.UserSession.OrgDocId, null);
            }
            
            obj.DistricsDDL = mobj.GetAllDistrics(0);
            obj.AddressTypes = mobj.GetAllAddressType(0);
            obj.GetAllOrgDocId = mobj.GetAllOrgDocIdForMadrassa(0);
            return View(obj);

            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }


        [HttpPost]
        public ActionResult CreateMadrassaAddress(MdlADDRESSS objform)
        {
             if (sig != null)
            {
            try
            {
                // TODO: Add insert logic here
                objform.EnterByUser_ID = sig.UserID;
                mobj.AddAddresss(objform);
                //TempData["foo1"] = "From Create";
                return RedirectToAction("MadrassaAddresses");
            }
            catch
            {

                obj.DistricsDDL = mobj.GetAllDistrics(0);
                obj.AddressTypes = mobj.GetAllAddressType(0);
                obj.GetAllOrgDocId = mobj.GetAllOrgDocIdForMadrassaAlterAddress(0);
                return View(obj);

            }

            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }



        public ActionResult UpdateMadrassaAddress(int id)
        {
             if (sig != null)
            {
            obj = mobj.EditADDRESSS(id);
            obj.DistricsDDL = mobj.GetAllDistrics(obj.Distric_ID);
            obj.AddressTypes = mobj.GetAllAddressType(obj.AdressType_ID);
            obj.GetAllOrgDocId = mobj.GetAllOrgDocIdForMadrassa(obj.OrgDoc_ID);

            return View(obj);

            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }

        // POST: Addresss/Edit/5
        [HttpPost]
        public ActionResult UpdateMadrassaAddress(MdlADDRESSS objform)
        {
             if (sig != null)
            {
            try
            {
                // TODO: Add update logic here
                objform.ModifyByUser_ID =sig.UserID;
                mobj.UpdateAddress(objform);
                return RedirectToAction("MadrassaAddresses");
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
        public ActionResult MadrassaAddresses()
        {
              if (sig != null)
            {
            objList = mobj.GetAllAddress(3);
            return View(objList);

            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }



        public ActionResult MadrassaAddressResolution()
        {
              if (sig != null)
            {
            obj.GetAllOrgDocId = mobj.GetAllOrgDocIdForMadrassaAlterAddress(0);
            obj.DistricsDDL = mobj.GetAllDistrics(0);
            obj.AddressTypes = mobj.GetAllAddressType(0);
            return View(obj);

            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }

        [HttpPost]
        public ActionResult MadrassaAddressResolution(MdlADDRESSS objform)
        {
               if (sig != null)
            {
            try
            {
                // TODO: Add insert logic here
                objform.EnterByUser_ID = sig.UserID;
                mobj.InsertFormBAlterAddress(objform);
                //TempData["foo1"] = "From Create";
                return RedirectToAction("MadrassaAddresses");
            }
            catch
            {
                obj.GetAllOrgDocId = mobj.GetAllOrgDocIdForMadrassaAlterAddress(0);
                obj.DistricsDDL = mobj.GetAllDistrics(0);
                obj.AddressTypes = mobj.GetAllAddressType(0);
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
        public ActionResult SocietyAddresses()
        {
               if (sig != null)
            {
           // objList = mobj.GetAllAddressForSociety();
            objList = mobj.GetAllAddress(2);
            return View(objList);

            }
               else
               {
                   return RedirectToAction("Index", "Login");
               }
        }
        

        public ActionResult CreateSocietyAddress(string Flag)
        {
             if (sig != null)
            {
            if (Flag == "SideBar")
            {
                UtilityClass.NullSession(UtilityClass.UserSession.OrgDocId, null);
            }
            
            obj.DistricsDDL = mobj.GetAllDistrics(0);
            obj.AddressTypes = mobj.GetAllAddressType(0);
            obj.GetAllOrgDocId = mobj.GetAllOrgDocIdForSocietyNGO(0);
            return View(obj);

            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }


        [HttpPost]
        public ActionResult CreateSocietyAddress(MdlADDRESSS objform)
        {
               if (sig != null)
            {
            try
            {
                // TODO: Add insert logic here
                objform.EnterByUser_ID = sig.UserID;
                mobj.AddAddresss(objform);
                //TempData["foo1"] = "From Create";
                return RedirectToAction("SocietyAddresses");
            }
            catch
            {

                obj.DistricsDDL = mobj.GetAllDistrics(0);
                obj.AddressTypes = mobj.GetAllAddressType(0);
                obj.GetAllOrgDocId = mobj.GetAllOrgDocIdForSocietyNGO(0);
                return View(obj);

            }

            }
               else
               {
                   return RedirectToAction("Index", "Login");
               }
        }



        public ActionResult UpdateSocietyAddress(int id)
        {   if (sig != null)
            {

            obj = mobj.EditADDRESSS(id);
            obj.DistricsDDL = mobj.GetAllDistrics(obj.Distric_ID);
            obj.AddressTypes = mobj.GetAllAddressType(obj.AdressType_ID);
            obj.GetAllOrgDocId = mobj.GetAllOrgDocIdForSocietyNGO(obj.OrgDoc_ID);

            return View(obj);

            }
        else
        {
            return RedirectToAction("Index", "Login");
        }
        }

        // POST: Addresss/Edit/5
        [HttpPost]
        public ActionResult UpdateSocietyAddress(MdlADDRESSS objform)
        {if (sig != null)
            {
            try
            {
                // TODO: Add update logic here
                objform.ModifyByUser_ID = sig.UserID;
                mobj.UpdateAddress(objform);
                return RedirectToAction("SocietyAddresses");
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



        public ActionResult SocietyAddressResolution()
        {
            if (sig != null)
            {
            obj.GetAllOrgDocId = mobj.GetAllOrgDocIdForSocietyNGOAlterAddress(0);
            obj.DistricsDDL = mobj.GetAllDistrics(0);
            obj.AddressTypes = mobj.GetAllAddressType(0);
            return View(obj);

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult SocietyAddressResolution(MdlADDRESSS objform)
        {
             if (sig != null)
            {
            try
            {
                // TODO: Add insert logic here
                objform.EnterByUser_ID = sig.UserID;
                mobj.InsertFormBAlterAddress(objform);
                //TempData["foo1"] = "From Create";
                return RedirectToAction("SocietyAddresses");
            }
            catch
            {
                obj.GetAllOrgDocId = mobj.GetAllOrgDocIdForSocietyNGOAlterAddress(0);
                obj.DistricsDDL = mobj.GetAllDistrics(0);
                obj.AddressTypes = mobj.GetAllAddressType(0);
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
