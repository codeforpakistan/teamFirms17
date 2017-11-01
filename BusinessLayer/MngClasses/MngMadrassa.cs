using BusinessLayer.MdlClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MngClasses
{
  public class MngMadrassa
    {

      # region crud ops

        private readonly dbFirmsEntities _dbFirms;
        public MngMadrassa()
        {

            if (_dbFirms == null)
            {
                _dbFirms = new dbFirmsEntities();
            }
        }

        public MdlFirm AddMadrassaData(MdlMadrassa obj)
        {
            MdlFirm  model = new MdlFirm();
       
            ObjectParameter objParamOrgID = new ObjectParameter("OrgID", typeof(long));
            ObjectParameter objParamOrgDocID = new ObjectParameter("OrgDocID", typeof(long));


            _dbFirms.usp_InsertMadrassa(
                
                obj.OrgRegNo,
             "Not Mention" , //obj.DurationofFirm old one
                DateTime.Now ,// old one obj.FormADate
               obj.ChallanNo, 
                obj.ChallanAmount,
                obj.FormGNo,
               DateTime.Now,// obj.MadrassaStartDate,
                3,
               // obj.OrgType_ID,
              
                obj.NotaryPublicName,
                obj.NotaryPublicLicenseNo,
                obj.MemoDate,
                obj.EnterByUser_ID,
                obj.MadrassaName,
                obj.IssueNo,
                obj.DocId,
                obj.SubmissionDate,
                obj.DocPath,                
                objParamOrgID,
                objParamOrgDocID,
                obj.FormHIssueDate,
                obj.FormHPath,
                obj.FormMemoPath,
                 obj.Remarks ,
			//  obj.FeeType_ID ,
			  obj.BankDistrict_ID ,
			 DateTime.Now,// obj.FeeDate  ,
              obj.Objectives,
              obj.SectType, obj.ExecutionDate,
           null,// obj.LicenseIssueDate,
            obj.BankID
                
                );
          

             model.OrgDocID = Convert.ToInt64(objParamOrgDocID.Value);
             model.OrgRegNo = obj.OrgRegNo;
             model.OrgName = obj.MadrassaName;
             return model;

          
          

        }

        public DataTable CreateDataTable(string[] Ids, long orgid)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("OrgID", typeof(long));
            dt.Columns.Add("BznsID", typeof(int));
            if (Ids != null && Ids.ToList().Count != 0)
            {

                foreach (string items in Ids.ToList())
                    dt.Rows.Add(orgid,items.ToString());
                

            }
            return dt;
        }

        public List<Dropdownlist> GetAllBusinessType()
        {
           var query= _dbFirms.BUSINESSTYPEs.ToList();
           List<Dropdownlist> list = new List<Dropdownlist>();
           foreach (var item in query)
           {
               list.Add(new Dropdownlist()
               {
                   Value = item.BusinessTypeID,
                   Label = item.BusinessTypeName,
                   
               });
           }
           return list;

        }


        public List<Dropdownlist> GetAllDistrics()
        {
            var query = _dbFirms.DISTRICTs.ToList();
            List<Dropdownlist> list = new List<Dropdownlist>();
            foreach (var item in query)
            {
                list.Add(new Dropdownlist()
                {
                    Value = item.DistrictID,
                    Label = item.DistrictName,

                });
            }
            return list;

        }
        public List<Dropdownlist> SectTypeDrp(int ID)
        {
            var query = _dbFirms.BUSINESSTYPEs.Where(e=>e.OfType==3).ToList();
            List<Dropdownlist> list = new List<Dropdownlist>();
            foreach (var item in query)
            {
                list.Add(new Dropdownlist()
                {
                    Value = item.BusinessTypeID,
                    Label = item.BusinessTypeName,
                    Selected=item.BusinessTypeID==ID?true:false

                });
            }
            return list;

        }
        public List<Dropdownlist> GetBankList(int ID)
        {
            var query = _dbFirms.BANKs.ToList();
            List<Dropdownlist> list = new List<Dropdownlist>();
            foreach (var item in query)
            {
                list.Add(new Dropdownlist()
                {
                    Value = item.BankID,
                    Label = item.BankName,
                    Selected = item.BankID == ID ? true : false

                });
            }
            return list;

        }
        public List<MdlMadrassa> GetAllMadrassa()
        {
            var query = _dbFirms.usp_GetAllMadrassa();
            List<MdlMadrassa> list = new List<MdlMadrassa>();
            foreach (var item in query)
            {
                list.Add(new MdlMadrassa()
                {
                    OrganizationID=item.OrganizationID,
                    MadrassaName=item.OrgName,
                   OrgRegNo=item.OrgRegNo,
                    DurationofFirm=item.DurationofFirm,
                    FormADate= item.FormADate,
                    FormADateString=Convert.ToDateTime(item.FormADate).ToShortDateString(),
                  //  ChallanNo=item.ChallanNo,
                  //  ChallanAmount=item.ChallanAmount,
                    FormGNo=item.FormGNo,
                    MadrassaStartDate=item.FirmStartDate,
                    MadrassaStartDateString=Convert.ToDateTime(item.FirmStartDate).ToShortDateString(),
                    OrgTypeName=item.OrgTypeName,
                    NotaryPublicName = item.NotaryPublicName,
                    NotaryPublicLicenseNo = item.NotaryPublicLicenseNo,
                    MemoDate = item.DeedAgreementDate,
                    MemoDateString=Convert.ToDateTime(item.DeedAgreementDate).ToShortDateString(),
                    IssueNo=item.IssueNo
                    
                    

                });
            }
            return list;

        }

        public  MdlMadrassa GetFirmDataForEdit(long ID)
        {
            var query = from o in _dbFirms.ORGANIZATIONs
                        join c in _dbFirms.ORGDOCs on o.OrganizationID equals c.Org_ID join d in _dbFirms.ORGDOCNAMEs on c.OrgDocID equals d.OrgDoc_ID
                        where o.OrganizationID == ID
                        select new
                        {
                            o.OrganizationID,o.OrgRegNo,o.DurationofFirm,o.FormADate,o.FormGNo,o.FirmStartDate,o.NotaryPublicName,o.NotaryPublicLicenseNo,o.DeedAgreementDate,
                            o.FormASubmissionDate,o.Remarks,d.OrgName
                        };
           //var item = _dbFirms.ORGANIZATIONs.Where(n=>n.OrganizationID==ID).SingleOrDefault();

            MdlMadrassa list = new MdlMadrassa();
                 
            foreach(var item1 in query)
            {
                list.OrganizationID = item1.OrganizationID; list.OrgRegNo = item1.OrgRegNo; list.DurationofFirm = item1.DurationofFirm;
                list.FormADate = item1.FormADate;
              
                list.FormADateString = Convert.ToDateTime(item1.FormADate).ToShortDateString();
                //  ChallanNo=item.ChallanNo;
                //  ChallanAmount=item.ChallanAmount;
                list.FormGNo = item1.FormGNo;
                list.MadrassaStartDate = item1.FirmStartDate;
                // list.FirmStartDateString = Convert.ToDateTime((item.FirmStartDate).ToString()).ToString("yyyy-mm-dd"); ;
                list.MadrassaStartDateString = Convert.ToDateTime(item1.FirmStartDate).ToShortDateString();
                // list.OrgTypeName = item.OrgTypeName;
                list.NotaryPublicName = item1.NotaryPublicName;
                list.NotaryPublicLicenseNo = item1.NotaryPublicLicenseNo;
                list.MemoDate = item1.DeedAgreementDate;
              
                list.MemoDateString = Convert.ToDateTime(item1.DeedAgreementDate).ToShortDateString();
                list.SubmissionDateString = Convert.ToDateTime(item1.FormASubmissionDate).ToShortDateString();
                list.SubmissionDate = item1.FormASubmissionDate;
                list.Remarks = item1.Remarks;
                list.MadrassaName = item1.OrgName;
                // list.IssueNo = item.IssueNo;

            }
 
            return list;

        }




        public void UpdateOldFirmData(MdlMadrassa obj)
        {
           // MdlFirm model = new MdlFirm();

            


            _dbFirms.usp_UpdateFirmBaiscInfo(
                obj.OrganizationID,
                obj.OrgRegNo,
                obj.DurationofFirm, 
                obj.FormADate,
              //  obj.ChallanNo,
              //  obj.ChallanAmount,
                obj.FormGNo,
                obj.MadrassaStartDate,
                // obj.OrgType_ID,
              obj.OrgType_ID,
                obj.NotaryPublicName,
                obj.NotaryPublicLicenseNo,
                obj.MemoDate,
                obj.EnterByUser_ID,
             
                obj.SubmissionDate,
             
                 obj.Remarks
            

                ); 
        }



      
      # endregion
        #region Resolution

        public List<Dropdownlist> GetAllOrgDocIdForMadrassa(long id)
        {

            // long id = 11;
            var query = _dbFirms.usp_GetAllFileNamesForMadrassa();
            //var query = _dbFirms.ORGDOCNAMEs.Where(x => x.IsActive == true).ToList();
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

        //here we getting orgDoc_ID and as well as an orginzation name for showing to the user
        //but on backend we shall implementing only their OrgDoc_ID for logic
        public List<Dropdownlist> GetAllOrgDocId(long id)
        {

            // long id = 11;
            var query = _dbFirms.usp_GetAllFileNames(0);
            //var query = _dbFirms.ORGDOCNAMEs.Where(x => x.IsActive == true).ToList();
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




        public MdlMadrassa InsertResolutionForAlterName(MdlMadrassa obj)
        {
            MdlMadrassa model = new MdlMadrassa();

            ObjectParameter objParamOrgDocID = new ObjectParameter("OrgDocID", typeof(long));


            _dbFirms.usp_InsertFormBAlterName(

                obj.OrgID,
                obj.MadrassaName,
                obj.FormBSubmissionDate,
                obj.FormBDocPath,
                obj.NewFormHIssueNo,
                obj.NewFormHIssueDate,
                obj.NewFormHDocPath,
                obj.EnterByUser_ID,
                objParamOrgDocID      
              

                );
 

            model.OrgDocID = Convert.ToInt64(objParamOrgDocID.Value);
            model.OrgRegNo = obj.MadrassaName;
           
            return model;




        }

        //public long InsertFormEinfo(MdlPartner obj)
        //{
        //    MdlPartner model = new MdlPartner();
        //    long OrgDocid;
        //    ObjectParameter objParamOrgDocID = new ObjectParameter("OrgDocID", typeof(long));
        //    _dbFirms.usp_InsertFormEnHEntry(

        //        obj.OrgId,
        //        obj.FormESubmissionDate,
        //        obj.FormEDocPath,
               
        //        obj.NewFormHIssueNo,
        //        obj.NewFormHIssueDate,
        //        obj.NewFormHDocPath,
        //        obj.EnterByUser_ID,
        //        objParamOrgDocID
        //        );
        //    OrgDocid = Convert.ToInt64(objParamOrgDocID.Value);
        //    return OrgDocid;

        //}
        //public MdlPartner DeactivatePartner(MdlPartner obj)
        //{
        //    MdlPartner model = new MdlPartner();

        //    ObjectParameter objParamOrgDocID = new ObjectParameter("OldOrgDocID", typeof(long));
        //    _dbFirms.usp_DeactivePartnersforAlteration(
        //        obj.OrgId,                
        //        obj.EnterByUser_ID,
        //        objParamOrgDocID
        //        );            
        //    model.OrgDoc_ID = Convert.ToInt64(objParamOrgDocID.Value);   
        //    return model;

        //}
        //public void UndoDeactivePartner(long  ID)
        //{
        //    MdlPartner model = new MdlPartner();


        //    _dbFirms.usp_UndoDeactivePartner(
        //        ID                             
        //        );            
           
           

        //}
        #endregion

    }
}
