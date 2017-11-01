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
   public  class MngSocietyNGO
    {
         # region crud ops

        private readonly dbFirmsEntities _dbFirms;
        public MngSocietyNGO()
        {

            if (_dbFirms == null)
            {
                _dbFirms = new dbFirmsEntities();
            }
        }

        public MdlFirm AddSocietyNGO(MdlSocietyNGO obj)
        {
            MdlFirm model = new MdlFirm(); 
       
            ObjectParameter objParamOrgID = new ObjectParameter("OrgID", typeof(long));
            ObjectParameter objParamOrgDocID = new ObjectParameter("OrgDocID", typeof(long));

            //@OrgRegNo, @DurationofFirm, @FormADate, @ChallanNo, @ChallanAmount, @FormGNo, @SocietyStartDate, @OrgType_ID, @NotaryPublicName, 
//            @NotaryLicense, @MemoDate, @User_ID, @SocietyName, @IssueNo, @DocID, @SubmissionDate, @DocPath, @OrgID, 
//            @OrgDocID, @FormHIssueDate, @FormHPath, @FormMemoPath, @Remarks,
//            @BankDistrict_ID, @FeeDate, @Objectives, @SocietyType, @ExecutionDate, @LicenseIssueDate, @BankID
            _dbFirms.usp_InsertSocietyNGO(
                
                obj.OrgRegNo,obj.DurationofFirm, obj.FormADate,obj.ChallanNo, 
                obj.ChallanAmount,
                obj.FormGNo,
                obj.SocietyStartDate, 2,
               // obj.OrgType_ID,
              
                obj.NotaryPublicName,
                obj.NotaryLicense,
                obj.MemoDate,
                obj.EnterByUser_ID,
                obj.SocietyName,
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
			  obj.FeeDate  ,
              obj.Objectives,
              obj.SocietyType, obj.ExecutionDate,
            obj.LicenseIssueDate, obj.BankID
                
                );
          

             model.OrgDocID = Convert.ToInt64(objParamOrgDocID.Value);
             model.OrgRegNo = obj.OrgRegNo;
             model.OrgName = obj.SocietyName;
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
        public List<Dropdownlist> SocietyTypeDrp(int ID)
        {
            var query = _dbFirms.BUSINESSTYPEs.Where(e=>e.OfType==2).ToList();
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
        public List<MdlSocietyNGO> GetAllSocietyNGO()
        {
            var query = _dbFirms.usp_GetAllSocietyNGO();
            List<MdlSocietyNGO> list = new List<MdlSocietyNGO>();
            foreach (var item in query)
            {
                list.Add(new MdlSocietyNGO()
                {
                    OrganizationID=item.OrganizationID,
                    SocietyName=item.OrgName,
                   OrgRegNo=item.OrgRegNo,
                    DurationofFirm=item.DurationofFirm,
                    FormADate= item.FormADate,
                    FormADateString=Convert.ToDateTime(item.FormADate).ToShortDateString(),
                  //  ChallanNo=item.ChallanNo,
                  //  ChallanAmount=item.ChallanAmount,
                    FormGNo=item.FormGNo,
                    SocietyStartDate = item.FirmStartDate,
                    SocietyStartDateString = Convert.ToDateTime(item.FirmStartDate).ToShortDateString(),
                    OrgTypeName=item.OrgTypeName,
                    NotaryPublicName = item.NotaryPublicName,
                    NotaryLicense = item.NotaryPublicLicenseNo,
                    MemoDate = item.DeedAgreementDate,
                    MemoDateString=Convert.ToDateTime(item.DeedAgreementDate).ToShortDateString(),
                    IssueNo=item.IssueNo
                    
                    

                });
            }
            return list;

        }





        #region Resolution
        public List<Dropdownlist> GetAllOrgDocIdForSocietyNGO(long id)
        {

            // long id = 11;
            var query = _dbFirms.usp_GetAllFileNamesForSocietyNGO();
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



        public MdlSocietyNGO InsertResolutionForAlterName(MdlSocietyNGO obj)
        {
            MdlSocietyNGO model = new MdlSocietyNGO();

            ObjectParameter objParamOrgDocID = new ObjectParameter("OrgDocID", typeof(long));


            _dbFirms.usp_InsertFormBAlterName(

                obj.OrgID,
                obj.SocietyName,
                obj.FormBSubmissionDate,
                obj.FormBDocPath,
                obj.NewFormHIssueNo,
                obj.NewFormHIssueDate,
                obj.NewFormHDocPath,
                obj.EnterByUser_ID,
                objParamOrgDocID


                );


            model.OrgDocID = Convert.ToInt64(objParamOrgDocID.Value);
            model.OrgRegNo = obj.SocietyName;

            return model;




        }
        #endregion



        



      
      # endregion
    }
}
