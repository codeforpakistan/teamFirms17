using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
  public  class MdlSocietyNGO
    {

      public string SocietyName { get; set; }
        public DateTime FormBSubmissionDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime LicenseIssueDate { get; set; }
        public string FormBDocPath { get; set; }
        public string NewFormHIssueNo { get; set; }
        public DateTime NewFormHIssueDate { get; set; }
        public string NewFormHDocPath { get; set; }
        public long OrganizationID { get; set; }
        public string OrgRegNo { get; set; }
        public string DurationofFirm { get; set; }
        public DateTime FormADate { get; set; }

        public string FormADateString { get; set; }
        public string ChallanNo { get; set; }
        public decimal ChallanAmount { get; set; }
        public string FormGNo { get; set; }
        public DateTime SocietyStartDate { get; set; }
        public string SocietyStartDateString { get; set; }
        public int OrgType_ID { get; set; }
        public int BusinessType_ID { get; set; }
        public string BusinessType_IDstring { get; set; }
        public string NotaryPublicName { get; set; }
        public string NotaryLicense { get; set; }
        public DateTime MemoDate { get; set; }
        public string MemoDateString { get; set; }
        public int EnterByUser_ID { get; set; }
        public DateTime EntryDate { get; set; }
        public int ModifyByUser_ID { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime IsActiveDate { get; set; }

        public string IssueNo { get; set; }

        public int DocId { get; set; }

        [Required(ErrorMessage = "Please enter Madrasa Name")]
        public string OrgName { get; set; }

        public DateTime SubmissionDate { get; set; }  // Form A + agreement
        public string SubmissionDateString { get; set; }
        public string DocPath { get; set; }   // Form A path

        public long OrgID { get; set; }

        public long OrgDocID { get; set; }
        public string OrgTypeName { get; set; }

        public string FormHPath { get; set; }

        public string FormMemoPath { get; set; }

        public DateTime FormHIssueDate { get; set; }

        public string[] BussinessTypeArry { get; set; }
        public string Remarks { get; set; }
        public int FeeType_ID { get; set; }
        public int BankDistrict_ID { get; set; }
        public DateTime FeeDate { get; set; }

        public string Objectives { get; set; }
        public int SocietyType { get; set; }
        public int BankID { get; set; }

        public List<Dropdownlist> SocietyTypeDrp = new List<Dropdownlist>();

        public List<Dropdownlist> BankDistrictList = new List<Dropdownlist>();

        public List<Dropdownlist> GetAllOrgDocId = new List<Dropdownlist>();


        public List<Dropdownlist> BanksList = new List<Dropdownlist>();
    }
}
