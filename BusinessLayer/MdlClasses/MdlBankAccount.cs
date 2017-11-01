using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
    public class MdlBankAccount
    {

        public long BankAccountID{ get; set; } 
        public string AccountTitle{ get; set; } 
        public int Bank_ID{ get; set; }
        public string BranchCode{ get; set; }
        public DateTime CreationDate { get; set; } 
        public int EnteredByUser_ID { get; set; }
        public DateTime EntryDate { get; set; }
        public int ModifyByUser_ID { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime IsActiveDate { get; set; }
        public long Org_ID { get; set; }

        public string BankName { get; set; }

        public string FileNo { get; set; }  // File no or OrgName ( Both are differnt, FileNo remains same while OrgName changes )

        public string EntryDateString { get; set; }

        public List<Dropdownlist> GetAllOrg_ID = new List<Dropdownlist>();
        public List<Dropdownlist> GetAllBank_ID = new List<Dropdownlist>();

      

    }
}
