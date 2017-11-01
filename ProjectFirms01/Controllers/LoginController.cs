using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProjectFirms01.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        #region Login
        public ActionResult Index()
        {
            return View();
        } 

        public ActionResult SignIn(string Username,string Password)
        {

            char[] charsToTrim = { ' ', '\t' };
            string trimUserName = Username.Trim(charsToTrim);
            string trimPassword = Password.Trim(charsToTrim);
            string pass = _Encyption(trimPassword);

            MdlUserLogin isverify = VerifyUser(trimUserName, pass);
            if(isverify !=null)
            {

                UtilityClass.AddUserSession(UtilityClass.UserSession.UserSessions, isverify);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Status"] = "User Name or Password is incorrect";
                return RedirectToAction("Index");
            }
            
             
        }

        public ActionResult SignOut()
        {
            UtilityClass.NullSession(UtilityClass.UserSession.UserSessions, null);
            UtilityClass.NullSession(UtilityClass.UserSession.OrgDocId, null);
            return RedirectToAction("Index");
        }
        public MdlUserLogin VerifyUser(string Username,string password)
        {
            MdlUserLogin Umodel = new MdlUserLogin();

            MngUserLogin Uapp = new MngUserLogin();
            Umodel = Uapp.GetUserInfo(Username, password);

            return Umodel;


        }

        private static string _Encyption(string text)
        {
           
            return Convert.ToBase64String(new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(text))); ;

        }
        #endregion

        #region User Registraion


        public ActionResult NewUserRegistration()
        {
            MdlUserLogin Umodel = new MdlUserLogin();

            MngUserLogin Uapp = new MngUserLogin();

            Umodel.UserRoleDrp = Uapp.GetRoledrp(0);

            return View(Umodel);
        }

        [HttpPost]
        public ActionResult NewUserRegistration( MdlUserLogin model)
        {
            MdlUserLogin Umodel = new MdlUserLogin();
            MngUserLogin Uapp = new MngUserLogin();
            try
            {
                string pass = _Encyption(model.Password);
                model.Password = pass;
                Uapp.AddNewUser(model);

                return RedirectToAction("UserList");
            }
            catch
            {
                Umodel.UserRoleDrp = Uapp.GetRoledrp(0);
                return View(Umodel);
            }
        }

        public ActionResult Edit(int id)
        {
            MdlUserLogin Umodel = new MdlUserLogin();

            MngUserLogin Uapp = new MngUserLogin();
            Umodel = Uapp.GetUserInfoForEdit(id);
            Umodel.UserRoleDrp = Uapp.GetRoledrp(Umodel.UserRoleID);

            return View(Umodel);
           
        }

        [HttpPost]
        public ActionResult Edit(MdlUserLogin model)
        {
            MdlUserLogin Umodel = new MdlUserLogin();

            MngUserLogin Uapp = new MngUserLogin();
            try
            {
                string pass = _Encyption(model.Password);
                model.Password = pass;
                model.EnterByUser_ID = 2;
                Uapp.ModifyUser(model);

                return RedirectToAction("UserList");
            }
            catch
            {
                Umodel.UserRoleDrp = Uapp.GetRoledrp(0);
                return View(Umodel);
            }
            

        }
        public ActionResult UserList()
        {
            List<MdlUserLogin> Umodel = new List<MdlUserLogin>();
            MngUserLogin Uapp = new MngUserLogin();

            Umodel = Uapp.GetAllUserList();

            return View(Umodel);
        }
        #endregion

    }
}