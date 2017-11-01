using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
   public class MdlUserLogin
    {
     //    UserID, UserName, Password, IsActive, UserEmail, UserContactNo
//    UserRoleID, User_ID, Role_ID, EntryDate, ModifyDate, EnterByUser_ID
             
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
       public bool IsActive { get; set; }

       public string IsActiveString { get; set; }
       public string UserEmail { get; set; }
       public string UserContactNo { get; set; }
       public int UserRoleID { get; set; }
       public int User_ID { get; set; }
       public int Role_ID { get; set; }

       public string RoleName { get; set; }
       public DateTime EntryDate { get; set; }
       public DateTime ModifyDate { get; set; }
       public int EnterByUser_ID { get; set; }

       public List<Dropdownlist> UserRoleDrp = new List<Dropdownlist>();

    }
}
