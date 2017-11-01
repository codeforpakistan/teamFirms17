using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
  public  class MdlRenewalReport
    {
       
    public long RReportID{get;set;}
    public int RReportYear{get;set;}
    public DateTime SubmissionDate{get;set;}
    public long Org_ID{get;set;}
    public DateTime RRResolutionDate{get;set;}
    public string RRResolutionDateString { get; set; }
    public bool IsAuthorityLetter{get;set;}
    public DateTime EntryDate{get;set;} 
    public int EnterByUser_ID{get;set;} 
    public DateTime ModifyDate{get;set;}
    public int ModifyByUser_ID { get; set; }
    public string OrgName { get; set; }

    public List<Dropdownlist> GetAllOrg_ID = new List<Dropdownlist>();

    }
}
