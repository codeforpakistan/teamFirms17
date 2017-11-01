using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer.MdlClasses
{
  public  class UtilityClass
    {


      public static void AddSession(string key, MdlFirm value)
          {
              HttpContext.Current.Session[key] = value;
          }

      public static void AddMadrassaSession(string key,MdlMadrassa value)
      {
          HttpContext.Current.Session[key] = value;
      }
      public static void AddPartnerSession(string key, MdlPartner value)
      {
          HttpContext.Current.Session[key] = value;
      }

      public static void AddUserSession(string key, MdlUserLogin value)
      {
          HttpContext.Current.Session[key] = value;
      }
          public static void NullSession(string key, string value)
          {
              HttpContext.Current.Session[key] = value;
          }



          public class UserSession
          {
              public static string OrgDocId = "OrgDocId";
              public static string UserSessions = "UserSession";
              public static string OrgIdforpartner = "OrgIdforpartner";

          }


          public static MdlFirm GetOrgDocIdSession(string key)
          {
              MdlFirm model = null;
              if (HttpContext.Current.Session[key] != null)
              {
                  model = (HttpContext.Current.Session[key]) as MdlFirm;
                  return model;
              }
              else
              {
                  return model;
              }

          }
          public static MdlPartner GetOrgIdSessionPartner(string key)
          {
              MdlPartner model = null;
              if (HttpContext.Current.Session[key] != null)
              {
                  model = (HttpContext.Current.Session[key]) as MdlPartner;
                  return model;
              }
              else
              {
                  return model;
              }

          }

          public static MdlUserLogin GetUserSession(string key)
          {
              MdlUserLogin model = null;
              if (HttpContext.Current.Session[key] != null)
              {
                  model = (HttpContext.Current.Session[key]) as MdlUserLogin;
                  return model;
              }
              else
              {
                  return model;
              }

          }
          public class UtilityMessages
          {
              public static string successmessage = "Record inserted successfully.";
              public static string successmsg = "Issue Assign Successfully.";
              public static string deletemessage = "Record deleted successfully.";
              public static string updatemessage = "Record updated successfully.";
              public static string errormessage = "Some error occurred. Please contact support team.";
              public static string alreadyexist = "The Assign Already Exist";
              public static string alreadyexisting = "This Acount Already Exist";

          }

          public class Enums
          {
              public enum ErrorClass
              {
                  error,
                  success
              }


              public enum UserRole
              {
                  Admin = 1,
                  User = 2,
                  Employee = 3,
                  Customers = 4,
                  QA = 11,
                  Support = 5,
                  LevelTwo = 14,
                  Manager = 16,
                  Hr = 17,
              }
          }
    }
}
