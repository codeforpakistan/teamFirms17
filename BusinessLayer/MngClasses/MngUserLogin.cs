using BusinessLayer.MdlClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MngClasses
{
  public  class MngUserLogin
    {

        private readonly dbFirmsEntities _dbFirms;
        public MngUserLogin()
        {

            if (_dbFirms == null)
            {
                _dbFirms = new dbFirmsEntities();
            }
        }

        #region Login
        public MdlUserLogin GetUserInfo(string Username,string passward)
        {
            var item=_dbFirms.USERs.Where(n=> n.UserName==Username && n.Password==passward).SingleOrDefault();
 MdlUserLogin list = new MdlUserLogin();
            //var query = from o in _dbFirms.ORGANIZATIONs  join c in _dbFirms.ORGDOCs on o.OrganizationID equals c.Org_ID
            //            join d in _dbFirms.ORGDOCNAMEs on c.OrgDocID equals d.OrgDoc_ID  where o.OrganizationID == ID
            //            select new
            //            {   o.OrganizationID,     o.OrgRegNo,      o.DurationofFirm,       o.FormADate,  d.OrgName  };
            if (item != null)
            {
               
                list.UserID = item.UserID;
                list.UserName = item.UserName;
                return list;
            }
            else
            {
                return list=null;
            }
            //foreach (var item in query)
            //{

            //    list.UserID = item.UserID;
            //    list.UserName = item.UserName;

            //    //list.FormGNo = item1.FormGNo;
            //    //list.FirmStartDate = item1.FirmStartDate;
            //    //// list.FirmStartDateString = Convert.ToDateTime((item.FirmStartDate).ToString()).ToString("yyyy-mm-dd"); ;
            //    //list.FirmStartDateString = Convert.ToDateTime(item1.FirmStartDate).ToShortDateString();
            //    //list.DeedAgreementDateString = Convert.ToDateTime(item1.DeedAgreementDate).ToShortDateString();


            //}



        }

        #endregion

        #region User Registration

        public void AddNewUser(MdlUserLogin obj)
        {

            _dbFirms.usp_InsertNewUserWithRole(
               obj.UserName,
               obj.Password,
               obj.UserEmail,
               obj.UserContactNo,
               obj.Role_ID

                );
        }


      public List<MdlUserLogin> GetAllUserList()
        {
            List<MdlUserLogin> model = new List<MdlUserLogin>();
            var query = from o in _dbFirms.USERs
                        join c in _dbFirms.USERROLEs on o.UserID equals c.User_ID
                        join d in _dbFirms.ROLEs on c.Role_ID equals d.RoleID
                      
                        select new { o.UserID, o.UserName, o.UserEmail, o.UserContactNo,o.IsActive, d.RoleName };

          foreach (var item in query)
          {
              model.Add(new MdlUserLogin{

                  UserID=item.UserID,
                  UserName=item.UserName,
                  UserEmail=item.UserEmail==null ? "----":item.UserEmail,
                  UserContactNo = item.UserContactNo == null ? "----" : item.UserContactNo,
                  IsActive=item.IsActive,
                  IsActiveString= item.IsActive==true? "Active":"In Active",
                  RoleName=item.RoleName
              });
          }
            return model;
        }



      public MdlUserLogin  GetUserInfoForEdit(int id)
      {
          MdlUserLogin  model = new  MdlUserLogin ();
          var query = from o in _dbFirms.USERs
                      join c in _dbFirms.USERROLEs on o.UserID equals c.User_ID
                      join d in _dbFirms.ROLEs on c.Role_ID equals d.RoleID
                      where o.UserID==id
                      select new { o.UserID, o.UserName, o.UserEmail, o.UserContactNo, o.IsActive,o.Password, c.UserRoleID };

          foreach (var item in query)
          {


              model.UserID = item.UserID;
              model.UserName = item.UserName;
              model.UserEmail = item.UserEmail == null ? "----" : item.UserEmail;
              model.UserContactNo = item.UserContactNo == null ? "----" : item.UserContactNo;
              model.IsActive = item.IsActive;
            //  model.IsActiveString = item.IsActive;
              model.UserRoleID = item.UserRoleID;
              model.Password = item.Password;
               
          }
          return model;
      }



      public  void ModifyUser(MdlUserLogin model)
      {
          USER u = _dbFirms.USERs.First(i => i.UserID == model.UserID);
          u.UserName = model.UserName;
          u.UserEmail = model.UserEmail;
          u.UserContactNo = model.UserContactNo;
          u.EntryDate = DateTime.Now;
          _dbFirms.SaveChanges();

          USERROLE ur = _dbFirms.USERROLEs.First(e => e.User_ID == model.UserID);
          ur.Role_ID = model.Role_ID;
          ur.ModifyDate = DateTime.Now;
          ur.EnterByUser_ID = model.EnterByUser_ID;
          _dbFirms.SaveChanges();
      }
        public List<Dropdownlist> GetRoledrp(int id)
        {
            var query = _dbFirms.GetAllRoles().ToList();
            List<Dropdownlist> list = new List<Dropdownlist>();
            foreach (var item in query)
            {
                list.Add(new Dropdownlist()
                {
                    Value = item.RoleID,
                    Label = item.RoleName,
                    Selected = item.RoleID == id ? true : false
                    

                });
            }
            return list;

        }
        #endregion



    }
}
