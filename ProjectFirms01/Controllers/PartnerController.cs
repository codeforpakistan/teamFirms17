using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFirms01.Controllers
{
    public class PartnerController : Controller
    {
        // GET: Partner
        MdlPartner obj = new MdlPartner();
        MngPartner mobj = new MngPartner();
        List<MdlPartner> Lobj = new List<MdlPartner>();
        MngADDRESSS MobjAddress = new MngADDRESSS();
        public readonly MdlUserLogin sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
        public ActionResult Index()
        {
             if (sig != null)
            {
            Lobj = mobj.GetAllPartnerList();
            return View(Lobj);
            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }

        // GET: Partner/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Partner/Create
        public ActionResult Create(string Flag)
        {
              if (sig != null)
            {
            if (Flag == "SideBar")
            {
                UtilityClass.NullSession(UtilityClass.UserSession.OrgDocId, null);
            }
           
            obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocId(0);
         //   obj.Designation = mobj.GetAllDesignation();
            return View(obj);
            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }

        // POST: Partner/Create
        [HttpPost]
        public ActionResult Create(MdlPartner obj)
        {
              if (sig != null)
            {
            try
            {
                // TODO: Add insert logic here
                obj.EnterByUser_ID =sig.UserID;
                mobj.AddNewPartner(obj);

                return RedirectToAction("Index");
            }
            catch
            {
                obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocId(0);
                return View(obj);
            }
            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }



        [HttpPost]
        public ActionResult SetShare(long PartnerID, int PartnerShare)
        {
            var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
            var Orgdoc = UtilityClass.GetOrgDocIdSession(UtilityClass.UserSession.OrgDocId);

            if (sig != null)
            {

                string message = string.Empty, status = string.Empty;
                try
                {
                    MdlPartner Pmodel = new MdlPartner();
                    MngPartner mobj = new MngPartner();
                    Pmodel.EnterByUser_ID = sig.UserID;
                    Pmodel.OrgDoc_ID = Convert.ToInt64(Orgdoc.OrgDocID.ToString());
                    Pmodel.PartnerID = PartnerID;
                    Pmodel.PartnerShare = PartnerShare;
                     mobj.SetPartnerShare(Pmodel);

                    
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
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        [HttpPost]
        public ActionResult NewFormHIssue(string NewFormHIssueNo, DateTime NewFormHIssueDate)
        {
            var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
            var Orgdoc = UtilityClass.GetOrgDocIdSession(UtilityClass.UserSession.OrgDocId);

            if (sig != null)
            {

                string message = string.Empty, status = string.Empty;
                try
                {
                    MdlPartner Pmodel = new MdlPartner();
                    MngPartner mobj = new MngPartner();
                    Pmodel.EnterByUser_ID = sig.UserID;
                    Pmodel.OrgDoc_ID = Convert.ToInt64(Orgdoc.OrgDocID.ToString());
                    Pmodel.NewFormHIssueNo = NewFormHIssueNo;
                    Pmodel.NewFormHIssueDate = NewFormHIssueDate;
                    mobj.NewFormHIssue(Pmodel);
                    SignOut();
                   
                    message = BusinessLayer.MdlClasses.UtilityClass.UtilityMessages.updatemessage.ToString();
                    status = BusinessLayer.MdlClasses.UtilityClass.Enums.ErrorClass.success.ToString();
                }
                catch (Exception ex)
                {
                    message = ex.Message;// BusinessLayer.MdlClasses.UtilityClass.UtilityMessages.errormessage.ToString();
                    status = BusinessLayer.MdlClasses.UtilityClass.Enums.ErrorClass.error.ToString();
                }

                return Json(new { status = status.ToString(), message = message.ToString() });

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public void SignOut()
        {
           
            UtilityClass.NullSession(UtilityClass.UserSession.OrgDocId, null);
             
        }
        public ActionResult FormEPartner(string Flag)
        {
              if (sig != null)
            {
            if (Flag == "SideBar")
            {
                UtilityClass.NullSession(UtilityClass.UserSession.OrgDocId, null);
            }

            obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocId(0);
            //   obj.Designation = mobj.GetAllDesignation();
            return View(obj);
            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }

        public ActionResult NewFormEPartner(string Flag)
        {
            if (sig != null)
            {
                if (Flag == "SideBar")
                {
                    UtilityClass.NullSession(UtilityClass.UserSession.OrgDocId, null);
                }

                obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocId(0);
                //   obj.Designation = mobj.GetAllDesignation();
                return View(obj);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult NewFormEPartner(MdlPartner obj)
        {

            if (sig != null)
            {
                try
                {
                    // TODO: Add insert logic here
                    obj.EnterByUser_ID = sig.UserID;
                    mobj.AddNewPartner(obj);

                    return RedirectToAction("NewFormEIndex");
                }
                catch(Exception ex)
                {
                    obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocId(0);

                    return View(obj);
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Partner/Edit/5
        public ActionResult NewFormEEdit(long id)
        {
            if (sig != null)
            {
                obj = mobj.GetPartnerDataForEdit(id);
                obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocId(obj.OrgDoc_ID);
                return View(obj);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Partner/Edit/5
        [HttpPost]
        public ActionResult NewFormEEdit(MdlPartner Pmodel)
        {
            if (sig != null)
            {
                try
                {
                    // TODO: Add update logic here
                    Pmodel.EnterByUser_ID = sig.UserID;
                    mobj.UpdatePartner(Pmodel);
                    return RedirectToAction("NewFormEIndex");
                }
                catch
                {
                    obj = mobj.GetPartnerDataForEdit(0);
                    obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocId(obj.OrgDoc_ID);
                    return View(obj);
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public ActionResult FormEPartner(MdlPartner obj)
        {
            
              if (sig != null)
            {
            try
            {
                // TODO: Add insert logic here
                obj.EnterByUser_ID = sig.UserID;
                mobj.AddNewPartner(obj);

                return RedirectToAction("FormEIndex");
            }
            catch
            {
                obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocId(0);
                 
                return View(obj);
            }
            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }



        public ActionResult FormEIndex()
        {
            var sig1 = UtilityClass.GetOrgDocIdSession(UtilityClass.UserSession.OrgDocId);
            long ID;
            if (sig != null)
            {
                //it will return the list during insert new partner throgh form H
                ID = Convert.ToInt32(sig1.OrgDocID.ToString());
                Lobj = mobj.GetAllFormEPartnerList(ID);
                return View(Lobj);
            }
            else
            {
                //if the session is null then it will retunr empty list
                ID = 0;
                Lobj = mobj.GetAllFormEPartnerList(ID);
                return View(Lobj);
            }
             
        }
        public ActionResult NewFormEIndex()
        {
             
            var sig1 = UtilityClass.GetOrgDocIdSession(UtilityClass.UserSession.OrgDocId);
            long ID;
            if (sig1 != null)
            {
                //it will return the list during insert new partner throgh form H
                ID = Convert.ToInt32(sig1.OrgDocID.ToString());
                Lobj = mobj.GetAllFormEPartnerList(ID);
                //it will return the list through organization ID
                //ID = Convert.ToInt32(sig1.ExistingOrgDocID.ToString());
                //Lobj = mobj.ListOfGoverningBodyForFormE(ID);
                return View(Lobj);
            }
            else
            {
                //if the session is null then it will retunr empty list
                ID = 0;
                Lobj = mobj.GetAllFormEPartnerList(ID);
                return View(Lobj);
            }

        }

        public ActionResult OutGoingPartner()
        {

            var sig1 = UtilityClass.GetOrgDocIdSession(UtilityClass.UserSession.OrgDocId);
            long ID;
            if (sig1 != null)
            {
                //it will return the list during insert new partner throgh form H
               // ID = Convert.ToInt32(sig1.OrgDocID.ToString());
               // Lobj = mobj.GetAllFormEPartnerList(ID);
                //it will return the list through organization ID
                ID = Convert.ToInt32(sig1.ExistingOrgDocID.ToString());
               // ID = Convert.ToUInt32(43);
                Lobj = mobj.ListOfGoverningBodyForFormE(ID);
                return View(Lobj);
            }
            else
            {
                //if the session is null then it will retunr empty list
                ID = 0;
                Lobj = mobj.ListOfGoverningBodyForFormE(ID);
                return View(Lobj);
            }

        }

        public ActionResult ShareSetting()
        {

            var sig1 = UtilityClass.GetOrgDocIdSession(UtilityClass.UserSession.OrgDocId);
            long ID;
            if (sig1 != null)
            {
                //it will return the list during insert new partner throgh form H
               // ID = Convert.ToInt32(sig1.OrgDocID.ToString());
               // Lobj = mobj.GetAllFormEPartnerList(ID);
                //it will return the list through organization ID
                ID = Convert.ToInt32(sig1.ExistingOrgDocID.ToString());


                Lobj = mobj.ListOfPartnerForFormEShareSetting(ID);
                return View(Lobj);
            }
            else
            {
                //if the session is null then it will retunr empty list
                ID = 0;
                Lobj = mobj.ListOfPartnerForFormEShareSetting(ID);
                return View(Lobj);
            }

        }
       
        // GET: Partner/Edit/5
        public ActionResult Edit(long id)
        { if (sig != null)
            {
            obj = mobj.GetPartnerDataForEdit(id);
            obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocId(obj.OrgDoc_ID);
            return View(obj);
            }
        else
        {
            return RedirectToAction("Index", "Login");
        }
        }

        // POST: Partner/Edit/5
        [HttpPost]
        public ActionResult Edit(MdlPartner Pmodel)
        {
            if (sig != null)
            {
            try
            {
                // TODO: Add update logic here
                Pmodel.EnterByUser_ID = sig.UserID;
                mobj.UpdatePartner(Pmodel);
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

        // GET: Partner/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Partner/Delete/5
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
        public ActionResult ListOfPartner(long Id)
       {
            //List<MdlPartner> model = new List<MdlPartner>();

            var sig1 = UtilityClass.GetOrgDocIdSession(UtilityClass.UserSession.OrgDocId);
            long ID;
            if (sig1 != null)
            {
                ID = Convert.ToInt32(sig1.OrgDocID.ToString());
                Lobj = mobj.OrgPartnerList(ID);
            }
            else
            {
                ID = Id;
                Lobj = mobj.OrgPartnerList(ID);
            }
            return PartialView("~/Views/Partner/PartialViews/_OrgPartnerList.cshtml", Lobj);
        }



        #region madrass

        public ActionResult GoverningBodyList()
        { if (sig != null)
            {
            Lobj = mobj.GetAllPartnerListForMadrassa();
            return View(Lobj);
            }
        else
        {
            return RedirectToAction("Index", "Login");
        }
        }
               // GET: Partner/Create
        public ActionResult GoverningBody(string Flag)
        {
            if (sig != null)
            {
            if (Flag == "SideBar")
            {
                UtilityClass.NullSession(UtilityClass.UserSession.OrgDocId, null);
            }
           
            obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocIdForMadrassa(0);
            obj.Designation = mobj.GetAllDesignation(0);
            return View(obj);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // POST: Partner/Create
        [HttpPost]
        public ActionResult GoverningBody(MdlPartner obj)
        {
             if (sig != null)
            {
            try
            {
                // TODO: Add insert logic here
                obj.EnterByUser_ID = sig.UserID;
                obj.PartnerShare = 0;
                mobj.AddNewPartner(obj);
                return RedirectToAction("GoverningBodyList");
            }
            catch
            {
                obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocIdForMadrassa(0);
                obj.Designation = mobj.GetAllDesignation(0);
                return View(obj);
            }
            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }

        // GET: Madrassa/Edit/5
        public ActionResult MadrassaGoverningBodyEdit(long id)
        {
              if (sig != null)
            {
            obj = mobj.GetPartnerDataForEdit(id);
            obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocIdForMadrassa(obj.OrgDoc_ID);
            obj.Designation = mobj.GetAllDesignation(obj.Designation_ID);
            return View(obj);
            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }

        // POST: Madrassa/Edit/5
        [HttpPost]
        public ActionResult MadrassaGoverningBodyEdit(MdlPartner Pmodel)
        { if (sig != null)
            {
            try
            {
                // TODO: Add update logic here
                Pmodel.EnterByUser_ID = sig.UserID;
                mobj.UpdatePartner(Pmodel);
                return RedirectToAction("GoverningBodyList");
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
        public ActionResult ListOfGoverningBody(long Id)
        {
            //List<MdlPartner> model = new List<MdlPartner>();

            var sig1 = UtilityClass.GetOrgDocIdSession(UtilityClass.UserSession.OrgDocId);
            long ID;
            if (sig != null)
            {
                ID = Convert.ToInt32(sig1.OrgDocID.ToString());
                Lobj = mobj.ListOfGoverningBody(ID);
            }
            else
            {
                ID = Id;
                Lobj = mobj.ListOfGoverningBody(ID);
            }
            return PartialView("~/Views/Partner/PartialViews/_MadrassaGoverningBodyList.cshtml", Lobj);
        }

        

        public ActionResult GoverningBodyAlterationList()
        {
            var sig1 = UtilityClass.GetOrgDocIdSession(UtilityClass.UserSession.OrgDocId);
            long ID;
            
            if (sig1 != null)
            {
                ID = Convert.ToInt32(sig1.ExistingOrgDocID.ToString());
                Lobj = mobj.ListOfGoverningBodyForFormE(ID);
                return View(Lobj);
            }
            else
            {
               // ID = Convert.ToInt32(sig.ExistingOrgDocID.ToString());
                Lobj = mobj.ListOfGoverningBodyForFormE(0);
                return View(Lobj);
            }
           
        }


        public ActionResult SocietyGoverningBodyAlterationList()
        {
            var sig1 = UtilityClass.GetOrgDocIdSession(UtilityClass.UserSession.OrgDocId);
            long ID;

            if (sig1 != null)
            {
                ID = Convert.ToInt32(sig1.ExistingOrgDocID.ToString());
                Lobj = mobj.ListOfGoverningBodyForFormE(ID);
                return View(Lobj);
            }
            else
            {
                //ID = Convert.ToInt32(sig.ExistingOrgDocID.ToString());
                Lobj = mobj.ListOfGoverningBodyForFormE(0);
                return View(Lobj);
            }

        }
           

        [HttpPost]
        public ActionResult DeactivateGoverningBody(long ID)
        {
            if (sig != null)
            {
            // var sig = UtilityClass.GetSession(UserSession.ESSSession);
            string message = string.Empty, status = string.Empty;
            try
            {
                MdlPartner Pmodel = new MdlPartner();
                MngPartner mobj = new MngPartner();
                Pmodel.EnterByUser_ID = sig.UserID;
                Pmodel.PartnerID = Convert.ToInt64(ID.ToString());
                Pmodel.IsActive = false;
               mobj.DeactivateGoverningBody(Pmodel);

              //  UtilityClass.AddPartnerSession(UtilityClass.UserSession.OrgIdforpartner, Pmodel);
                message = BusinessLayer.MdlClasses.UtilityClass.UtilityMessages.updatemessage.ToString();
                status = BusinessLayer.MdlClasses.UtilityClass.Enums.ErrorClass.success.ToString();
            }
            catch (Exception ex)
            {
                message = ex.Message;// BusinessLayer.MdlClasses.UtilityClass.UtilityMessages.errormessage.ToString();
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
        public ActionResult ActivateGoverningBody(long ID)
        {
            // var sig = UtilityClass.GetSession(UserSession.ESSSession);
            if (sig != null)
            {
            string message = string.Empty, status = string.Empty;
            try
            {
                MdlPartner Pmodel = new MdlPartner();
                MngPartner mobj = new MngPartner();
                Pmodel.EnterByUser_ID = sig.UserID;
                Pmodel.PartnerID = Convert.ToInt64(ID.ToString());
                Pmodel.IsActive = true;
               mobj.DeactivateGoverningBody(Pmodel);

              //  UtilityClass.AddPartnerSession(UtilityClass.UserSession.OrgIdforpartner, Pmodel);
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
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }



        public ActionResult GoverningBodywithAlterForm(string Flag)
        {
              if (sig != null)
            {
            if (Flag == "SideBar")
            {
                UtilityClass.NullSession(UtilityClass.UserSession.OrgDocId, null);
            }

        
            obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocIdForMadrassa(0);
            obj.Designation = mobj.GetAllDesignation(0);
            return View(obj);
            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }

        // POST: Partner/Create
        [HttpPost]
        public ActionResult GoverningBodywithAlterForm(MdlPartner obj)
        {  if (sig != null)
            {
            try
            {
                // TODO: Add insert logic here
                obj.EnterByUser_ID = sig.UserID;
                obj.PartnerShare = 0;
                mobj.AddNewPartner(obj);
                return RedirectToAction("GoverningBodyAlterationList");
            }
            catch
            {
                obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocIdForMadrassa(0);
                obj.Designation = mobj.GetAllDesignation(0);
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

        public ActionResult NGOGoverningBodyList()
        {
            if (sig != null)
            {
            Lobj = mobj.GetAllPartnerListForSociety();
            return View(Lobj);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
               // GET: Partner/Create
        public ActionResult NGOGoverningBody(string Flag)
        {
             if (sig != null)
            {
            if (Flag == "SideBar")
            {
                UtilityClass.NullSession(UtilityClass.UserSession.OrgDocId, null);
            }

            obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocIdForSocietyNGO(0);
            obj.Designation = mobj.GetAllDesignation(0);
            return View(obj);
            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }

        // POST: Partner/Create
        [HttpPost]
        public ActionResult NGOGoverningBody(MdlPartner obj)
        {
              if (sig != null)
            {
            try
            {
                // TODO: Add insert logic here
                obj.EnterByUser_ID = sig.UserID;
                obj.PartnerShare = 0;
                mobj.AddNewPartner(obj);
                return RedirectToAction("NGOGoverningBodyList");
            }
            catch
            {
                obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocIdForSocietyNGO(0);
                obj.Designation = mobj.GetAllDesignation(0);
                return View(obj);
            }
            }
              else
              {
                  return RedirectToAction("Index", "Login");
              }
        }

        public ActionResult SocietyGoverningBodyEdit(long id)
        {
               if (sig != null)
            {
            obj = mobj.GetPartnerDataForEdit(id);
            obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocIdForSocietyNGO(obj.OrgDoc_ID);
            obj.Designation = mobj.GetAllDesignation(obj.Designation_ID);
            return View(obj);
            }
               else
               {
                   return RedirectToAction("Index", "Login");
               }
        }

        // POST: Madrassa/Edit/5
        [HttpPost]
        public ActionResult SocietyGoverningBodyEdit(MdlPartner Pmodel)
        { if (sig != null)
            {
            try
            {
                // TODO: Add update logic here
                Pmodel.EnterByUser_ID = sig.UserID;
                mobj.UpdatePartner(Pmodel);
                return RedirectToAction("NGOGoverningBodyList");
            }
            catch
            {
                obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocIdForSocietyNGO(0);
                obj.Designation = mobj.GetAllDesignation(0);
                return View(obj);
            }
            }
        else
        {
            return RedirectToAction("Index", "Login");
        }
        }



        public ActionResult SocietyGoverningBodywithAlterForm(string Flag)
        {
             if (sig != null)
            {
            if (Flag == "SideBar")
            {
                UtilityClass.NullSession(UtilityClass.UserSession.OrgDocId, null);
            }

          
            obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocIdForSocietyNGO(0);
            obj.Designation = mobj.GetAllDesignation(0);
            return View(obj);
            }
             else
             {
                 return RedirectToAction("Index", "Login");
             }
        }

        // POST: Partner/Create
        [HttpPost]
        public ActionResult SocietyGoverningBodywithAlterForm(MdlPartner obj)
        { if (sig != null)
            {
            try
            {
                // TODO: Add insert logic here
                obj.EnterByUser_ID = sig.UserID;
                obj.PartnerShare = 0;
                mobj.AddNewPartner(obj);
                return RedirectToAction("SocietyGoverningBodyAlterationList");
            }
            catch
            {
                obj.GetAllOrgDocId = MobjAddress.GetAllOrgDocIdForSocietyNGO(0);
                obj.Designation = mobj.GetAllDesignation(0);
                return View(obj);
            }
            }
        else
        {
            return RedirectToAction("Index", "Login");
        }
        }

        #endregion


        # region form D

        //public ActionResult CreateNewFormD()
        //{
        //    MdlPartnerAdressName obj = new MdlPartnerAdressName();
        //    MngPartner mobj1 = new MngPartner();
        //    MngFirm mobj = new MngFirm();
        //    obj.GetAllOrg_ID = mobj.GetAllOrgDocId(0);
           
        //  //  obj.GetAllPartner_ID = mobj1.ListOfPartnerForFormEShareSetting();           
        //    return View(obj);
        //}

        public ActionResult CreateNewFormD()
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
        public ActionResult CreateNewFormD(MdlPartner model)
        {

            var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);

            if (sig != null)
            {
                try
                {
                    model.EnterByUser_ID = sig.UserID;
                    MngPartner mobj = new MngPartner();
                    MdlPartner Pmodel = new MdlPartner();

                    MdlFirm Fmodel = new MdlFirm();

                    Fmodel = mobj.AddNewFormDnH(model);
 
                    UtilityClass.AddSession(UtilityClass.UserSession.OrgDocId, Fmodel);
                    //Passing Orgdocid to partner Session Model                
                    return RedirectToAction("NewNameAndAddress", "Partner");
                }
                catch (Exception ex)
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

        public ActionResult NewNameAndAddress()
        {

            var sig1 = UtilityClass.GetOrgDocIdSession(UtilityClass.UserSession.OrgDocId);
            long ID;
            if (sig1 != null)
            {
                //it will return the list during insert new partner throgh form H
                // ID = Convert.ToInt32(sig1.OrgDocID.ToString());
                // Lobj = mobj.GetAllFormEPartnerList(ID);
                //it will return the list through organization ID
                ID = Convert.ToInt32(sig1.ExistingOrgDocID.ToString());


                Lobj = mobj.ListOfPartnerForFormEShareSetting(ID);
                return View(Lobj);
            }
            else
            {
                //if the session is null then it will retunr empty list
                ID = 0;
                Lobj = mobj.ListOfPartnerForFormEShareSetting(ID);
                return View(Lobj);
            }

        }

        [HttpPost]
        public ActionResult SetNameandAddressFormD(long PartnerID, string PartnerAddress, string PartnerName)
        {
            var sig = UtilityClass.GetUserSession(UtilityClass.UserSession.UserSessions);
            var Orgdoc = UtilityClass.GetOrgDocIdSession(UtilityClass.UserSession.OrgDocId);

            if (sig != null)
            {

                string message = string.Empty, status = string.Empty;
                try
                {
                    MdlPartner Pmodel = new MdlPartner();
                    MngPartner mobj = new MngPartner();
                    Pmodel.EnterByUser_ID = sig.UserID;
                    Pmodel.OrgDoc_ID = Convert.ToInt64(Orgdoc.OrgDocID.ToString());
                    Pmodel.PartnerID = PartnerID;
                    Pmodel.PartnerAddress = PartnerAddress;
                    Pmodel.PartnerName = PartnerName;


                    mobj.AddNewFormDAddressName(Pmodel);


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
 
                    UtilityClass.AddSession(UtilityClass.UserSession.OrgDocId, Fmodel);                    
                    return RedirectToAction("NewFormEIndex", "Partner");
                }
                catch (Exception ex)
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
        public JsonResult GetPartnerListByOrgId(long ID, long Partner_ID)
        {
            List<Dropdownlist> list = new List<Dropdownlist>();
            list = mobj.ListOfPartnerForFormD(ID, Partner_ID);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
      
       
        # endregion


    }
}
