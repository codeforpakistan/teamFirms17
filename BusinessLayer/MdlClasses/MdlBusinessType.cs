using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
    public class MdlBusinessType
    {

        public int BusinessTypeID { get; set; }
        public int OrgTypeID { get; set; }
        public string OrgTypeName { get; set; }

      ///  [Required(ErrorMessage = "Please enter Bussiness Name")]
        public string BusinessTypeName { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public int EnteredByUser_ID { get; set; }
        public DateTime EntryTime { get; set; }
        public int UpdateByUser_ID { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UserName { get; set; }


        public List<Dropdownlist> AllOrgTypes = new List<Dropdownlist>();
    }
}
