//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLayer
{
    using System;
    
    public partial class usp_GetAuditReportsofRenewalReport_Result
    {
        public long AuditReportID { get; set; }
        public int AuditReportYear { get; set; }
        public string CharteredAcct { get; set; }
        public decimal TotalDonation { get; set; }
        public long RenewalReport_ID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int EnteredByUser_ID { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<int> ModifyByUser_ID { get; set; }
    }
}