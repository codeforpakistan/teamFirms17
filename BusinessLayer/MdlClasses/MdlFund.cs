using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
    public class MdlFund
    {

        public long FundSourceID { get; set; } 
        public string FundSourceName { get; set; } 
        public int FundSourceType { get; set; } 
        public string TransferMeans { get; set; } 
        public decimal TransferAmount { get; set; } 
        public int EnteredByUser_ID { get; set; }
        public DateTime EntryDate { get; set; }
        public int ModifyByUser_ID { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime IsActiveDate { get; set; }
        public long Org_ID { get; set; }

        public List<Dropdownlist> GetAllOrg_ID = new List<Dropdownlist>();

        public string FileNo { get; set; }  // File no or OrgName ( Both are differnt, FileNo remains same while OrgName changes )
        public int RcvYear { get; set; }
    }
}
