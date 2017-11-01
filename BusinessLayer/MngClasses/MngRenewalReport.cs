using BusinessLayer.MdlClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MngClasses
{
    public class MngRenewalReport
    {

        private readonly dbFirmsEntities _dbFirms;
        public MngRenewalReport()
        {

            if (_dbFirms == null)
            {
                _dbFirms = new dbFirmsEntities();
            }
        }


       
        public void AddNewRenewalReport(MdlRenewalReport obj)
        {
            _dbFirms.usp_InsertRenewalReport(obj.RReportYear, obj.SubmissionDate, obj.Org_ID, obj.RRResolutionDate, obj.IsAuthorityLetter,obj.EnterByUser_ID);
        }

        public void UpdateRenewalReport(MdlRenewalReport obj)
        {
            _dbFirms.usp_UpdateRenewalReport(obj.RReportID,obj.RReportYear, obj.SubmissionDate, obj.Org_ID, obj.RRResolutionDate, obj.IsAuthorityLetter, obj.ModifyByUser_ID);
        }


        public List<MdlRenewalReport> GetAllRenewalReportsofOrgList(long orgid)
        {
            var query = _dbFirms.usp_GetOrgRenewalReports(orgid);
            List<MdlRenewalReport> list = new List<MdlRenewalReport>();
            foreach (var item in query)
            {
                list.Add(new MdlRenewalReport()
                {
                 RReportID = item.RReportID,
                 RReportYear = item.RReportYear,
                 IsAuthorityLetter = item.IsAuthorityLetter,
                  RRResolutionDate = item.RRResolutionDate.Value,
                  EntryDate = item.EntryDate              
                 
                          });
            }
            return list;
        }

        public List<MdlRenewalReport> GetAllRenewalReport(long orgid)
        {
            var query = from r in _dbFirms.RENREPORTs

                        join org in _dbFirms.ORGANIZATIONs on r.Org_ID equals org.OrganizationID
                        join orgdoc in _dbFirms.ORGDOCs on org.OrganizationID equals orgdoc.Org_ID
                        join orgnam in _dbFirms.ORGDOCNAMEs on orgdoc.OrgDocID equals orgnam.OrgDoc_ID
                        where orgdoc.Document_ID == 2 && r.Org_ID == orgid
                        select new
                        {
                            r.RReportID,
                            r.IsAuthorityLetter,
                            r.RReportYear,
                            r.RRResolutionDate,
                            r.SubmissionDate,
                            r.Org_ID,
                            orgnam.OrgName

                        };


            List<MdlRenewalReport> list = new List<MdlRenewalReport>();

            foreach (var item in query)
            {

                list.Add(new MdlRenewalReport()
                {
                    RReportID = item.RReportID,
                    RReportYear = item.RReportYear,
                    RRResolutionDateString = Convert.ToDateTime(item.RRResolutionDate.ToString()).ToShortDateString(),
                    SubmissionDate = item.SubmissionDate,
                    Org_ID = item.Org_ID,
                    OrgName = item.OrgName,
                    IsAuthorityLetter = item.IsAuthorityLetter

                });
            }
            return list;

        }

       public List<Dropdownlist> GetAllOrgDocIdForSocietyNGO(long id)
        {        
            var query = _dbFirms.usp_GetAllFileNamesForSocietyNGO();          
            List<Dropdownlist> list = new List<Dropdownlist>();
            foreach (var item in query)
            {
                list.Add(new Dropdownlist()
                {
                    Value = item.OrganizationID,
                    Label = item.OrgName,
                    OptionalLabel = item.OrgRegNo,
                    Selected = item.OrgDoc_ID == id ? true : false

                });
            }
            return list;

        }

       public List<Dropdownlist> GetAllRenewalReportsofOrg(long orgid)
       {
           var query = _dbFirms.usp_GetOrgRenewalReports(orgid);
           List<Dropdownlist> list = new List<Dropdownlist>();
           foreach (var item in query)
           {
               list.Add(new Dropdownlist()
               {
                   Value = item.RReportID,
                   Label = item.RReportYear.ToString(),
                   // OptionalLabel = 
                   // Selected = item.OrgDoc_ID == id ? true : false

               });
           }
           return list;
       }

    }
}
