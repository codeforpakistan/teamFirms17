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
    
    public partial class USERROLE
    {
        public int UserRoleID { get; set; }
        public int User_ID { get; set; }
        public int Role_ID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<int> EnterByUser_ID { get; set; }
    }
}
