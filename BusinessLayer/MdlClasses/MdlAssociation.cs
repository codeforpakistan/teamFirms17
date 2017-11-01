using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
    public class MdlAssociation
    {
   public long AssociationID { get; set; }
   public int AssociationType { get; set; }    
   public string AssociationTitle { get; set; }
   public DateTime AssociationDate { get; set; } 
   public string Duration { get; set; } 
   public DateTime ExpiryDate { get; set; }
   public int EnteredByUser_ID { get; set; }
   public DateTime EntryDate{ get; set; }
   public int ModifyByUser_ID{ get; set; }
   public DateTime  ModifyDate{ get; set; }
   public bool IsActive{ get; set; }
   public DateTime IsActiveDate{ get; set; }
   public long Org_ID{ get; set; }

   public string FileNo { get; set; }  // File no or OrgName ( Both are differnt, FileNo remains same while OrgName changes )

   public List<Dropdownlist> GetAllOrg_ID = new List<Dropdownlist>();
}
}
