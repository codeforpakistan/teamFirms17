using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
    public class MdlPartnerAdressName
    {
        public long PAdressID{ get; set; }
        public long Partner_ID { get; set; }
        public string PartnerNewName { get; set; } 
        public string PartnerAdress { get; set; }
        public long OrgDoc_ID { get; set; }
        public int EnterByUser_ID { get; set; }
        public DateTime EntryDate { get; set; }
        public int ModifyByUser_ID { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsActive{ get; set; }
        public DateTime IsActiveDate { get; set; }
        public string FileNo { get; set; }
        public string PartnerName { get; set; }

        public List<Dropdownlist> GetAllOrg_ID = new List<Dropdownlist>();
        public List<Dropdownlist> GetAllPartner_ID = new List<Dropdownlist>();
        
    }
}
