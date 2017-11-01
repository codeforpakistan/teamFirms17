using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
    public class MdlADDRESSS
    {
        public long AdressID { get; set; }
        public long OrgDoc_ID { get; set; }
        public int AdressType_ID { get; set; }
        public string AdressDetails { get; set; }
        public int Tehsil_ID { get; set; }
        public int Distric_ID { get; set; }
        public int EnterByUser_ID { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryDateString { get; set; }
        public int ModifyByUser_ID { get; set; }
        public string AdressTypeName { get; set; }
        public DateTime ModifyByDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime IsActiveDate { get; set; }
        public long OrgId { get; set; }
        public long OldAdressId { get; set; }
        public DateTime FormBSubmissionDate { get; set; }
        public string FormBDocPath { get; set; }
        public string NewFormHIssueNo { get; set; }
        public DateTime NewFormHIssueDate { get; set; }
        public string NewFormHDocPath { get; set; }
        public string TehsilName { get; set; }
        public string OrgName { get; set; }
        public string UserName { get; set; }  public string OrgRegNo { get; set; }

        public List<Dropdownlist> DistricsDDL = new List<Dropdownlist>();
        public List<Dropdownlist> TehsilDDL = new List<Dropdownlist>();
        public List<Dropdownlist> AddressTypes = new List<Dropdownlist>();
        public List<Dropdownlist> GetAllOrgDocId = new List<Dropdownlist>();
        //public virtual ORGDOC ORGDOC { get; set; }
        //public virtual TEHSIL TEHSIL { get; set; }
    }
}
