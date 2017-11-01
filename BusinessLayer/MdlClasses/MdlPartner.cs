using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
    public class MdlPartner
    {

        public long PartnerID { get; set; }
        public string OrgName { get; set; }
        public string OrgRegNo { get; set; }
        public string PartnerName { get; set; }
        public string PartnerCNIC { get; set; }
        public string PartnerONIC { get; set; }
        public double PartnerShare { get; set; }
        public string PartnerAddress { get; set; }
        public string PartnerContactNo { get; set; }
        public string PartnerMobileNo { get; set; }
        public string PartnerCitizenNo { get; set; }
        public string PartnerPassportNo { get; set; }
        public long OrgDoc_ID { get; set; }
        public int EnterByUser_ID { get; set; }
        public DateTime EntryDate { get; set; }
        public int? ModifyByUser_ID { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool IsActive { get; set; }

        public string Active { get; set; }
        public DateTime? IsActiveDate { get; set; }
        public string NICImagePath { get; set; }
        public int Designation_ID { get; set; }
        public int NationalityID { get; set; }
        public string Occupation { get; set; }
        public List<Dropdownlist> GetAllOrgDocId = new List<Dropdownlist>();
        public List<Dropdownlist> Designation = new List<Dropdownlist>();

        public List<Dropdownlist> GetAllOrgId = new List<Dropdownlist>();
        public long OrgId { get; set; }
        public DateTime FormESubmissionDate { get; set; }
       
        public string FormEDocPath { get; set; }
        public string NewFormHIssueNo { get; set; }
        public DateTime NewFormHIssueDate { get; set; }
        public string NewFormHDocPath { get; set; }

        public DateTime FormDSubmissionDate { get; set; }
        public string FormDDocPath { get; set; }



    }
}
