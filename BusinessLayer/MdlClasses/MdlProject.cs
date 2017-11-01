using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
    public class MdlProject
    {
        public long ProjectID{get;set;}
        public string ProjectTitle{get;set;}
        public DateTime StartDate{get;set;}
        public long Org_ID{get;set;}
        public bool IsComplete{get;set;}
        public int EnteredByUser_ID{get;set;}
        public DateTime EntryDate{get;set;}
        public int ModifyByUser_ID{get;set;}
        public DateTime ModifyDate{get;set;}
        public bool IsActive{get;set;}
        public DateTime IsActiveDate{get;set;}
        public string FileNo { get; set; } // fileno or Orgname

        public List<Dropdownlist> GetAllOrg_ID = new List<Dropdownlist>();

    }
}
