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
    
    public partial class TEHSIL
    {
        public TEHSIL()
        {
            this.ADDRESSSes = new HashSet<ADDRESSS>();
        }
    
        public int TehsilID { get; set; }
        public string TehsilName { get; set; }
        public int District_ID { get; set; }
    
        public virtual ICollection<ADDRESSS> ADDRESSSes { get; set; }
        public virtual DISTRICT DISTRICT { get; set; }
    }
}
