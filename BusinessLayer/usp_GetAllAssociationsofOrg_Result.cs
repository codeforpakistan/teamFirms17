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
    
    public partial class usp_GetAllAssociationsofOrg_Result
    {
        public long AssociationID { get; set; }
        public string AssociationTitle { get; set; }
        public int AssociationType { get; set; }
        public System.DateTime AssociationDate { get; set; }
        public string Duration { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public int EnteredByUser_ID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> IsActiveDate { get; set; }
        public long OrganizationID { get; set; }
        public string OrgRegNo { get; set; }
    }
}
