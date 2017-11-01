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
    using System.Collections.Generic;
    
    public partial class ORGDOC
    {
        public ORGDOC()
        {
            this.ADDRESSSes = new HashSet<ADDRESSS>();
            this.ORGDOCNAMEs = new HashSet<ORGDOCNAME>();
            this.PARTNERs = new HashSet<PARTNER>();
            this.WITNESSes = new HashSet<WITNESS>();
        }
    
        public long OrgDocID { get; set; }
        public long Org_ID { get; set; }
        public int Document_ID { get; set; }
        public Nullable<System.DateTime> SubmissionDate { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int EnterByUser_ID { get; set; }
        public Nullable<int> ModifyByUser_ID { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string DocumentPath { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> IsActiveDate { get; set; }
        public string IssueNo { get; set; }
    
        public virtual ICollection<ADDRESSS> ADDRESSSes { get; set; }
        public virtual DOCUMENT DOCUMENT { get; set; }
        public virtual ORGANIZATION ORGANIZATION { get; set; }
        public virtual ICollection<ORGDOCNAME> ORGDOCNAMEs { get; set; }
        public virtual ICollection<PARTNER> PARTNERs { get; set; }
        public virtual ICollection<WITNESS> WITNESSes { get; set; }
    }
}