using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
    public class MdlStaff
    { 
        public long StaffID { get; set; }     
        public int StaffType{ get; set; }
        public int Designation_ID{ get; set; } 
        public string Name{ get; set; } 
        public string CNIC{ get; set; } 
        public string ContactNo{ get; set; } 
        public decimal Salary{ get; set; } 
        public int EnteredByUser_ID { get; set; }
        public DateTime EntryDate { get; set; }
        public int ModifyByUser_ID { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime IsActiveDate { get; set; }
        public long Org_ID { get; set; }

        public List<Dropdownlist> GetAllOrg_ID = new List<Dropdownlist>();
        public List<Dropdownlist> GetAllDesig_ID = new List<Dropdownlist>();

        public string FileNo { get; set; }  // File no or OrgName ( Both are differnt, FileNo remains same while OrgName changes )

        public string DesignationName { get; set; }

    }
}
