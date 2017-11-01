using BusinessLayer.MdlClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MngClasses
{
    public class MngFirm
    {

      # region crud ops

        private readonly dbFirmsEntities _dbFirms;
        public MngFirm()
        {

            if (_dbFirms == null)
            {
                _dbFirms = new dbFirmsEntities();
            }
        }

        public List<MdlCount> GetCount()
        {
            var query = _dbFirms.usp_GetRegisteredOrgsCount();
            List<MdlCount> list = new List<MdlCount>();
            foreach (var item in query)
            {
                list.Add(new MdlCount()
                {
                    Total =int.Parse(item.Total.ToString()),
                    OrgTypeName = item.OrgTypeName,

                });
            }
            return list;
        }
        public MdlFirm AddOldFirmData(MdlFirm obj)
        {
            MdlFirm model = new MdlFirm();
            
            // @OrgRegNo, @DurationofFirm, @FormADate, @ChallanNo, @ChallanAmount, @FormGNo, @FirmStartDate, @OrgType_ID, @NotaryPublicName, 
            // @NotaryLicense, @AgreementDate, @User_ID, @OrgRegName, @IssueNo, @DocID, @SubmissionDate, @DocPath, @OrgID, @OrgDocID, @FormHIssueDate,
            // @FormHPath, @FormAgreementPath                    
       
            ObjectParameter objParamOrgID = new ObjectParameter("OrgID", typeof(long));
            ObjectParameter objParamOrgDocID = new ObjectParameter("OrgDocID", typeof(long));


            _dbFirms.usp_InsertOldFirmData(
                
                obj.OrgRegNo, obj.DurationofFirm, obj.FormADate,obj.ChallanNo, 
                obj.ChallanAmount,
                obj.FormGNo,
                obj.FirmStartDate,
               // obj.OrgType_ID,
               1,
                obj.NotaryPublicName,
                obj.NotaryPublicLicenseNo,
                obj.DeedAgreementDate,
                obj.EnterByUser_ID,
                obj.OrgName,
                obj.IssueNo,
                obj.DocId,
                obj.SubmissionDate,
                obj.DocPath,                
                objParamOrgID,
                objParamOrgDocID,
                obj.FormHIssueDate,
                obj.FormHPath,
                obj.FormAgmtPath,
                 obj.Remarks ,
			//  obj.FeeType_ID ,
			  obj.BankDistrict_ID ,
			  obj.FeeDate,  obj.ExecutionDate,
            obj.LicenseIssueDate,obj.BankID
              
                
                );

            DataTable dt = CreateDataTable(obj.BussinessTypeArry, Convert.ToInt64(objParamOrgID.Value));
            SqlParameter codesParam = new SqlParameter("@Tvp", SqlDbType.Structured);
            codesParam.Value = dt;
            codesParam.TypeName = "dbo.OrgBznsType";
            _dbFirms.Database.ExecuteSqlCommand("exec usp_InsertOrgBusiness @Tvp", codesParam);


             model.OrgDocID = Convert.ToInt64(objParamOrgDocID.Value);
             model.OrgRegNo = obj.OrgRegNo;
             model.OrgName = obj.OrgName;
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
           var query= _dbFirms.BUSINESSTYPEs.Where(n=>n.OfType==1).ToList();
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



        public List<Dropdownlist> GetAllBanks(int Id)
        {
            var query = _dbFirms.BANKs.ToList();
            List<Dropdownlist> list = new List<Dropdownlist>();
            foreach (var item in query)
            {
                list.Add(new Dropdownlist()
                {
                    Value = item.BankID,
                    Label = item.BankName,
                    Selected=item.BankID==Id?true:false

                });
            }
            return list;

        }

        public List<MdlFirm> GetAllFirms()
        {
            var query = _dbFirms.usp_GetAllFirms();
            List<MdlFirm> list = new List<MdlFirm>();
            foreach (var item in query)
            {
                list.Add(new MdlFirm()
                {
                    OrganizationID=item.OrganizationID,
                    OrgName=item.OrgName,
                   OrgRegNo=item.OrgRegNo,
                    DurationofFirm=item.DurationofFirm,
                    FormADate= item.FormADate,
                    FormADateString=Convert.ToDateTime(item.FormADate).ToShortDateString(),
                  //  ChallanNo=item.ChallanNo,
                  //  ChallanAmount=item.ChallanAmount,
                    FormGNo=item.FormGNo,
                    FirmStartDate=item.FirmStartDate,
                    FirmStartDateString=Convert.ToDateTime(item.FirmStartDate).ToShortDateString(),
                    OrgTypeName=item.OrgTypeName,
                    NotaryPublicName = item.NotaryPublicName,
                    NotaryPublicLicenseNo = item.NotaryPublicLicenseNo,
                    DeedAgreementDate = item.DeedAgreementDate,
                    DeedAgreementDateString=Convert.ToDateTime(item.DeedAgreementDate).ToShortDateString(),
                    IssueNo=item.IssueNo
                    
                    

                });
            }
            return list;

        }

        public  MdlFirm GetFirmDataForEdit(long ID)
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

           MdlFirm  list = new MdlFirm();
                 
            foreach(var item1 in query)
            {
                list.OrganizationID = item1.OrganizationID; list.OrgRegNo = item1.OrgRegNo; list.DurationofFirm = item1.DurationofFirm;
                list.FormADate = item1.FormADate;
              
                list.FormADateString = Convert.ToDateTime(item1.FormADate).ToShortDateString();
                //  ChallanNo=item.ChallanNo;
                //  ChallanAmount=item.ChallanAmount;
                list.FormGNo = item1.FormGNo;
                list.FirmStartDate = item1.FirmStartDate;
                // list.FirmStartDateString = Convert.ToDateTime((item.FirmStartDate).ToString()).ToString("yyyy-mm-dd"); ;
                list.FirmStartDateString = Convert.ToDateTime(item1.FirmStartDate).ToShortDateString();
                // list.OrgTypeName = item.OrgTypeName;
                list.NotaryPublicName = item1.NotaryPublicName;
                list.NotaryPublicLicenseNo = item1.NotaryPublicLicenseNo;
                list.DeedAgreementDate = item1.DeedAgreementDate;
              
                list.DeedAgreementDateString = Convert.ToDateTime(item1.DeedAgreementDate).ToShortDateString();
                list.SubmissionDateString = Convert.ToDateTime(item1.FormASubmissionDate).ToShortDateString();
                list.SubmissionDate = item1.FormASubmissionDate;
                list.Remarks = item1.Remarks;
                list.OrgName = item1.OrgName;
                // list.IssueNo = item.IssueNo;

            }
 
            return list;

        }




        public void UpdateOldFirmData(MdlFirm obj)
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
                obj.FirmStartDate,
                // obj.OrgType_ID,
              obj.OrgType_ID,
                obj.NotaryPublicName,
                obj.NotaryPublicLicenseNo,
                obj.DeedAgreementDate,
                obj.EnterByUser_ID,
             
                obj.SubmissionDate,
             
                 obj.Remarks
            

                ); 
        }



      
      # endregion
        #region FormB



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

        public List<Dropdownlist> GetAllOrgDocIdForNGOSociety(long id)
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
        public MdlFirm InsertFormBAlterName(MdlFirm obj)
        {
            MdlFirm model = new MdlFirm();

            ObjectParameter objParamOrgDocID = new ObjectParameter("OrgDocID", typeof(long));


            _dbFirms.usp_InsertFormBAlterName(

                obj.OrgID,
                obj.OrgRegName,
                obj.FormBSubmissionDate,
                obj.FormBDocPath,
                obj.NewFormHIssueNo,
                obj.NewFormHIssueDate,
                obj.NewFormHDocPath,
                obj.EnterByUser_ID,
                objParamOrgDocID      
              

                );
 

            model.OrgDocID = Convert.ToInt64(objParamOrgDocID.Value);
            model.OrgRegNo = obj.OrgRegName;
           
            return model;




        }





        public long InsertFormEinfo(MdlPartner obj)
        {
            MdlPartner model = new MdlPartner();
            long OrgDocid;
            ObjectParameter objParamOrgDocID = new ObjectParameter("OrgDocID", typeof(long));
            _dbFirms.usp_InsertFormEnHEntry(

                obj.OrgId,
                obj.FormESubmissionDate,
                obj.FormEDocPath,               
                obj.NewFormHIssueNo,
                obj.NewFormHIssueDate,
                obj.NewFormHDocPath,
                obj.EnterByUser_ID,
                objParamOrgDocID
                );
            OrgDocid = Convert.ToInt64(objParamOrgDocID.Value);
            return OrgDocid;

        }

        public MdlFirm InsertNewFormEinfo(MdlPartner obj)
        {
            MdlFirm Fmodel = new MdlFirm();
            MdlPartner model = new MdlPartner();
           
            ObjectParameter objParamOrgDocID = new ObjectParameter("OrgDocID", typeof(long));
            _dbFirms.usp_InsertFormEnHEntry(

                obj.OrgId,
                obj.FormESubmissionDate,
                obj.FormEDocPath,
                obj.NewFormHIssueNo,
             null,
                obj.NewFormHDocPath,
                obj.EnterByUser_ID,
                objParamOrgDocID
                );
            Fmodel.ExistingOrgDocID = obj.OrgId;
            Fmodel.OrgName = obj.OrgName;
           
             Fmodel.OrgDocID = Convert.ToInt64(objParamOrgDocID.Value);

             return Fmodel;

        }
  public MdlFirm InsertMadrassaFormEinfo(MdlPartner obj)
        {
            MdlFirm model = new MdlFirm();
           
            ObjectParameter objParamOrgDocID = new ObjectParameter("OrgDocID", typeof(long));
            _dbFirms.usp_InsertFormEnHEntry(

                obj.OrgId,
                obj.FormESubmissionDate,
                obj.FormEDocPath,               
                obj.NewFormHIssueNo,
                obj.NewFormHIssueDate,
                obj.NewFormHDocPath,
                obj.EnterByUser_ID,
                objParamOrgDocID
                );


            model.OrgDocID = Convert.ToInt64(objParamOrgDocID.Value);
            model.ExistingOrgDocID = obj.OrgId;
            model.OrgName = obj.OrgName;
            return model;

        }

  public MdlFirm InsertNGOSocietyFormEinfo(MdlPartner obj)
  {
      MdlFirm model = new MdlFirm();

      ObjectParameter objParamOrgDocID = new ObjectParameter("OrgDocID", typeof(long));
      _dbFirms.usp_InsertFormEnHEntry(

          obj.OrgId,
          obj.FormESubmissionDate,
          obj.FormEDocPath,
          obj.NewFormHIssueNo,
          obj.NewFormHIssueDate,
          obj.NewFormHDocPath,
          obj.EnterByUser_ID,
          objParamOrgDocID
          );


      model.OrgDocID = Convert.ToInt64(objParamOrgDocID.Value);
      model.ExistingOrgDocID = obj.OrgId;
      model.OrgName = obj.OrgName;
      return model;

  }
        public MdlPartner DeactivatePartner(MdlPartner obj)
        {
            MdlPartner model = new MdlPartner();

            ObjectParameter objParamOrgDocID = new ObjectParameter("OldOrgDocID", typeof(long));
            _dbFirms.usp_DeactivePartnersforAlteration(
                obj.OrgId,                
                obj.EnterByUser_ID,
                objParamOrgDocID
                );            
            model.OrgDoc_ID = Convert.ToInt64(objParamOrgDocID.Value);   
            return model;

        }
        public void UndoDeactivePartner(long  ID)
        {
            MdlPartner model = new MdlPartner();


            _dbFirms.usp_UndoDeactivePartner(
                ID                             
                );            
           
           

        }
        #endregion

    }
}
