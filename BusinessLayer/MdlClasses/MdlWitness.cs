using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
    public class MdlWitness
    {

        public long WitnessID { get; set; }
        public string WitnessName { get; set; }
        public string OrgRegNo { get; set; }
        public string WitnessCNIC { get; set; }
        public string WitnessONIC { get; set; }
        public string WitnessAddress { get; set; }
        public string WitnessContactNo { get; set; }
        public string WitnessMobileNo { get; set; }
        public long OrgDoc_ID { get; set; }
        public string WitnessPassportNo { get; set; }
        public string WitnessCitizenNo { get; set; }
        public int EnterByUser_ID { get; set; }
        public DateTime EntryDate { get; set; }
        public int? ModifyByUser_ID { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? IsActiveDate { get; set; }
        public List<Dropdownlist> GetAllOrgDocId = new List<Dropdownlist>();

    }
}
