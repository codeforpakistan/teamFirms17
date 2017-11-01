using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
    public class MdlAuditReport
    {

        public long AuditReportID{ get; set; } 
        public int  AuditReportYear{ get; set; } 
        public string CharteredAcct{ get; set; } 
        public decimal TotalDonation{ get; set; } 
        public long RenewalReport_ID{ get; set; }
        public int EnteredByUser_ID { get; set; }
        public DateTime EntryDate { get; set; }
        public int ModifyByUser_ID { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime IsActiveDate { get; set; }
        public long Org_ID { get; set; }

        public string EntryDateString { get; set; }

        public List<Dropdownlist> GetAllOrg_ID = new List<Dropdownlist>();
        public List<Dropdownlist> GetRenewalReport_ID = new List<Dropdownlist>(); 

    }
}
