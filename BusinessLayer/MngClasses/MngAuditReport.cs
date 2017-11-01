using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.MdlClasses;

namespace BusinessLayer.MngClasses
{
    public class MngAuditReport
    {

        private readonly dbFirmsEntities _dbFirms;
        public MngAuditReport()
        {

            if (_dbFirms == null)
            {
                _dbFirms = new dbFirmsEntities();
            }
        }

        public void AddNewAuditReport(MdlAuditReport obj)
        {
            _dbFirms.usp_InsertAuditReport(obj.AuditReportYear,obj.CharteredAcct,obj.TotalDonation,obj.RenewalReport_ID,obj.EnteredByUser_ID);
        }

        public void UpdateAuditReport(MdlAuditReport obj)
        {
           _dbFirms.usp_UpdateAuditReport(obj.AuditReportID, obj.AuditReportYear, obj.CharteredAcct, obj.TotalDonation, obj.RenewalReport_ID, obj.ModifyByUser_ID);
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

        public List<Dropdownlist> GetAllOrgIDNName(long id)
        {
            var query = _dbFirms.usp_GetAllFileNames(0);
            List<Dropdownlist> list = new List<Dropdownlist>();
            foreach (var item in query)
            {
                list.Add(new Dropdownlist()
                {
                    Value = item.OrganizationID,
                    Label = item.OrgName,
                    OptionalLabel = item.OrgRegNo,
                    Selected = item.OrganizationID == id ? true : false

                });
            }
            return list;

        } 

        //public List<Dropdownlist> GetRenewalReportsofOrg(long OrgId)
        //{


        //    var query = _dbFirms.usp_GetOrgRenewalReports(OrgId);
        //    List<Dropdownlist> list = new List<Dropdownlist>();
        //    foreach (var item in query)
        //    {
        //        list.Add(new Dropdownlist()
        //        {
        //            Value = item.RReportID,
        //            Label = item.RReportYear.ToString(),
        //            OptionalLabel = item.FileNo,
        //            Selected = item.OrganizationID == OrgId ? true : false

        //        });
        //    }
        //    return list;

        //}


        // update it 
        public List<MdlAuditReport> GetAllAuditReportsofRenewalReport(long rrid)
        {
            var query = _dbFirms.usp_GetAuditReportsofRenewalReport(rrid);
            List<MdlAuditReport> list = new List<MdlAuditReport>();
            foreach (var item in query)
            {

                list.Add(new MdlAuditReport()
                {
                    AuditReportID = item.AuditReportID,
                    AuditReportYear = item.AuditReportYear,
                    RenewalReport_ID = item.RenewalReport_ID,
                    CharteredAcct = item.CharteredAcct,
                    TotalDonation = item.TotalDonation,
                    EntryDateString = item.EntryDate.ToShortDateString(),
                });
            }
            return list;

        }


    }
}
