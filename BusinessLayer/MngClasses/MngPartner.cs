using BusinessLayer.MdlClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MngClasses
{
  public class MngPartner
    {
        private readonly dbFirmsEntities _dbFirms;
        public MngPartner()
        {

            if (_dbFirms == null)
            {
                _dbFirms = new dbFirmsEntities();
            }
        }


      public List<MdlPartner> GetAllPartnerList()
        {
            //var query = _dbFirms.PARTNERs.ToList();
            var query = _dbFirms.usp_GetPartnersofOrgType(1);
            var list = new List<MdlPartner>();
          foreach(var obj in query)
          {
              list.Add(new MdlPartner
              {
                  PartnerID=obj.PartnerID,
                  PartnerName = obj.PartnerName,
                  PartnerCNIC = obj.PartnerCNIC,
                  PartnerONIC = obj.PartnerONIC,
                  PartnerShare = obj.PartnerShare,
                  PartnerAddress = obj.PartnerAddress,
                  PartnerContactNo = obj.PartnerContactNo,
                  PartnerMobileNo = obj.PartnerMobileNo,
                  PartnerCitizenNo = obj.PartnerCitizenNo,
                  PartnerPassportNo = obj.PartnerPassportNo,
                  OrgDoc_ID = obj.OrgDoc_ID,
                  EnterByUser_ID = obj.EnterByUser_ID,
                  NICImagePath = obj.NICImagePath,
                  Designation_ID = obj.Designation_ID,
                  Occupation = obj.Occupation,
                  IsActive=obj.IsActive
              });

          }
          return list;
        }
      public List<MdlPartner> GetAllPartnerListForMadrassa()
      {
          var query = _dbFirms.usp_GetPartnersofOrgType(3);
          var list = new List<MdlPartner>();
          foreach (var obj in query)
          {
              list.Add(new MdlPartner
              {
                  PartnerID = obj.PartnerID,
                  PartnerName = obj.PartnerName,
                  PartnerCNIC = obj.PartnerCNIC,
                  PartnerONIC = obj.PartnerONIC,
                  PartnerShare = obj.PartnerShare,
                  PartnerAddress = obj.PartnerAddress,
                  PartnerContactNo = obj.PartnerContactNo,
                  PartnerMobileNo = obj.PartnerMobileNo,
                  PartnerCitizenNo = obj.PartnerCitizenNo,
                  PartnerPassportNo = obj.PartnerPassportNo,
                  OrgDoc_ID = obj.OrgDoc_ID,
                  EnterByUser_ID = obj.EnterByUser_ID,
                  NICImagePath = obj.NICImagePath,
                  Designation_ID = obj.Designation_ID,
                  Occupation = obj.Occupation,
                  IsActive=obj.IsActive
              });

          }
          return list;
      }
      public List<MdlPartner> GetAllPartnerListForSociety()
      {
          var query = _dbFirms.usp_GetPartnersofOrgType(2);
          var list = new List<MdlPartner>();
          foreach (var obj in query)
          {
              list.Add(new MdlPartner
              {
                  PartnerID = obj.PartnerID,
                  PartnerName = obj.PartnerName,
                  PartnerCNIC = obj.PartnerCNIC,
                  PartnerONIC = obj.PartnerONIC,
                  PartnerShare = obj.PartnerShare,
                  PartnerAddress = obj.PartnerAddress,
                  PartnerContactNo = obj.PartnerContactNo,
                  PartnerMobileNo = obj.PartnerMobileNo,
                  PartnerCitizenNo = obj.PartnerCitizenNo,
                  PartnerPassportNo = obj.PartnerPassportNo,
                  OrgDoc_ID = obj.OrgDoc_ID,
                  EnterByUser_ID = obj.EnterByUser_ID,
                  NICImagePath = obj.NICImagePath,
                  Designation_ID = obj.Designation_ID,
                  Occupation = obj.Occupation
              });

          }
          return list;
      }
      public List<MdlPartner> GetAllFormEPartnerList(long ID)
      {
          var query = _dbFirms.usp_GetPartnersUsingOrgDocId(ID).ToList();
          var list = new List<MdlPartner>();
          foreach (var obj in query)
          {
              list.Add(new MdlPartner
              {
                  PartnerID = obj.PartnerID,
                  PartnerName = obj.PartnerName,
                  PartnerCNIC = obj.PartnerCNIC,
                  PartnerONIC = obj.PartnerONIC,
                  PartnerShare = obj.PartnerShare,
                  PartnerAddress = obj.PartnerAddress,
                  PartnerContactNo = obj.PartnerContactNo,
                  PartnerMobileNo = obj.PartnerMobileNo,
                  PartnerCitizenNo = obj.PartnerCitizenNo,
                  PartnerPassportNo = obj.PartnerPassportNo,
                  OrgDoc_ID = obj.OrgDoc_ID,
                  EnterByUser_ID = obj.EnterByUser_ID,
                  NICImagePath = obj.NICImagePath,
                  Designation_ID = obj.Designation_ID,
                  Occupation = obj.Occupation,
                  IsActive=obj.IsActive
              });

          }
          return list;
      }

      public  MdlPartner GetPartnerDataForEdit(long id)
      {
          var obj = _dbFirms.PARTNERs.Where(n=>n.PartnerID==id).SingleOrDefault();
          var list = new  MdlPartner();
          //foreach (var obj in query)
          //{
          list.PartnerID = obj.PartnerID;
                 list.PartnerName = obj.PartnerName;
                  list.PartnerCNIC = obj.PartnerCNIC;
                  list.PartnerONIC = obj.PartnerONIC;
                  list.PartnerShare = obj.PartnerShare;
                  list.PartnerAddress = obj.PartnerAddress;
                  list.PartnerContactNo = obj.PartnerContactNo;
                  list.PartnerMobileNo = obj.PartnerMobileNo;
                  list.PartnerCitizenNo = obj.PartnerCitizenNo;
                  list.PartnerPassportNo = obj.PartnerPassportNo;
                  list.OrgDoc_ID = obj.OrgDoc_ID;
                  list.EnterByUser_ID = obj.EnterByUser_ID;
                  list.NICImagePath = obj.NICImagePath;
                  list.Designation_ID = obj.Designation_ID;
                  list.Occupation = obj.Occupation;
              

          //}
          return list;
      }
      public List<Dropdownlist> GetAllDesignation(int id)
      {
          // long id = 11;
          var query = _dbFirms.DESIGNATIONs.ToList();
          List<Dropdownlist> list = new List<Dropdownlist>();
          foreach (var item in query)
          {
              list.Add(new Dropdownlist()
              {
                  Value = item.DesignationID,
                  Label = item.DesignationName,
                  Selected = item.DesignationID == id ? true : false

              });
          }
          return list;

      }

      public void NewFormHIssue(MdlPartner obj)
      {
          _dbFirms.usp_UpdateFormHIssueInfo(             
              obj.OrgDoc_ID,
              obj.NewFormHIssueDate,
              obj.NewFormHIssueNo,              
              obj.EnterByUser_ID
              );


      }
      public void SetPartnerShare(MdlPartner obj)
      {
          _dbFirms.usp_InsertPartnerShareforNewFormE(

             obj.PartnerID,
             obj.OrgDoc_ID,
              obj.PartnerShare,
              obj.EnterByUser_ID
              

              );


      }
        public void AddNewPartner(MdlPartner obj)
        {
            _dbFirms.usp_InsertNewPartner(

                obj.PartnerName,
                obj.PartnerCNIC,
                obj.PartnerONIC,
                obj.PartnerShare,
                obj.PartnerAddress,
                obj.PartnerContactNo,
                obj.PartnerMobileNo,
                obj.PartnerCitizenNo,
                obj.PartnerPassportNo,
                obj.OrgDoc_ID,
                obj.EnterByUser_ID,
                obj.NICImagePath,
                obj.Designation_ID,
                obj.Occupation,
                obj.NationalityID

                );


        }

        public void UpdatePartner(MdlPartner obj)
        {
            _dbFirms.usp_UpdatePartner(
                obj.PartnerID,
                obj.PartnerName,
                obj.PartnerCNIC,
                obj.PartnerONIC,
                obj.PartnerShare,
                obj.PartnerAddress,
                obj.PartnerContactNo,
                obj.PartnerMobileNo,
                obj.PartnerCitizenNo,
                obj.PartnerPassportNo,
                obj.OrgDoc_ID,
                obj.EnterByUser_ID,
                obj.NICImagePath,
                obj.Designation_ID,
                obj.Occupation,
                obj.NationalityID

                );


        }
        public List<MdlPartner> OrgPartnerList(long Id)
        {
            // long id = 11;
            var query = _dbFirms.PARTNERs.Where(n=>n.OrgDoc_ID==Id).ToList();
            List<MdlPartner> list = new List<MdlPartner>();
            foreach (var item in query)
            {
                list.Add(new MdlPartner()
                {
                    PartnerName = item.PartnerName,
                    PartnerCNIC = item.PartnerCNIC,
                    PartnerShare=item.PartnerShare

                    // Selected = item.OrgDoc_ID == id ? true : false

                });
            }
            return list;

        }

        public List<MdlPartner> ListOfGoverningBody(long Id)
        {
            // long id = 11;
            var query = _dbFirms.PARTNERs.Where(n => n.OrgDoc_ID == Id).ToList();
            List<MdlPartner> list = new List<MdlPartner>();
            foreach (var item in query)
            {
                list.Add(new MdlPartner()
                {
                    PartnerName = item.PartnerName,
                    PartnerCNIC = item.PartnerCNIC,
                    PartnerAddress = item.PartnerAddress

                    // Selected = item.OrgDoc_ID == id ? true : false

                });
            }
            return list;

        }

        public List<MdlPartner> ListOfGoverningBodyForFormE(long Id)
        {
            // long id = 11;

            //organization id and document id required
            var query = _dbFirms.usp_GetPartnersUsingOrgIdForMadrassa(Id,2);
            List<MdlPartner> list = new List<MdlPartner>();
            foreach (var item in query)
            {
                list.Add(new MdlPartner()
                {
                    PartnerName = item.PartnerName,
                    PartnerCNIC = item.PartnerCNIC,
                    PartnerAddress = item.PartnerAddress,
                    PartnerContactNo=item.PartnerContactNo,
                    PartnerMobileNo=item.PartnerMobileNo,
                    OrgDoc_ID=item.OrgDoc_ID,
                    IsActive=item.IsActive ,
                    PartnerShare=item.PartnerShare,
                 
                    PartnerID=item.PartnerID
                    

                    // Selected = item.OrgDoc_ID == id ? true : false

                });
            }
            return list;

        }
   public List<MdlPartner> ListOfPartnerForFormEShareSetting(long Id)
        {
            // long id = 11;

            //organization id and document id required
            var query = _dbFirms.usp_GetPartnersUsingOrgIdForFirm(Id, 2);
            List<MdlPartner> list = new List<MdlPartner>();
            foreach (var item in query)
            {
                list.Add(new MdlPartner()
                {
                    PartnerName = item.PartnerName,
                    PartnerCNIC = item.PartnerCNIC,
                    PartnerAddress = item.PartnerAddress,
                    PartnerContactNo=item.PartnerContactNo,
                    PartnerMobileNo=item.PartnerMobileNo,
                    OrgDoc_ID=item.OrgDoc_ID,
                    IsActive=item.IsActive ,
                    PartnerShare=item.PartnerShare,
                 
                    PartnerID=item.PartnerID
                    

                    // Selected = item.OrgDoc_ID == id ? true : false

                });
            }
            return list;

        }

   public List<Dropdownlist> ListOfPartnerForFormD(long Id, long partnerid)
   {
       // long id = 11;
       var query = _dbFirms.usp_GetPartnersUsingOrgIdForFirm(Id, 2);
       List<Dropdownlist> list = new List<Dropdownlist>();
       foreach (var item in query)
       {
           list.Add(new Dropdownlist()
           {
               Value = item.PartnerID,
               Label = item.PartnerName,
               Selected = item.PartnerID == partnerid ? true : false

           });
       }
       return list;
       
      
       

   }
        public void DeactivateGoverningBody(MdlPartner obj)
        {
            MdlPartner model = new MdlPartner();

          //  ObjectParameter objParamOrgDocID = new ObjectParameter("OldOrgDocID", typeof(long));
            _dbFirms.usp_DeactivePartner(
                obj.PartnerID,
                obj.IsActive,
                obj.EnterByUser_ID
                );
          //  model.OrgDoc_ID = Convert.ToInt64(objParamOrgDocID.Value);
         //   return model;

        }

      public void AddNewFormDAddressName(MdlPartner obj)
        {
            //  _dbFirms (obj.Partner_ID,obj.PartnerAdress,obj.OrgDoc_ID,obj.EnterByUser_ID)
            _dbFirms.usp_InsertFormDPartnerNameORAddress(obj.PartnerID, obj.PartnerName, obj.PartnerAddress, obj.OrgDoc_ID, obj.EnterByUser_ID);

        }

        public void UpdateFormDAddressName(MdlPartnerAdressName obj)
        {
            //  _dbFirms (obj.Partner_ID,obj.PartnerAdress,obj.OrgDoc_ID,obj.EnterByUser_ID)
            _dbFirms.usp_UpdateFormDPartnerNameORAddress(obj.PAdressID,obj.Partner_ID, obj.PartnerName, obj.PartnerAdress, obj.OrgDoc_ID,obj.ModifyByUser_ID);

        }

        public MdlFirm AddNewFormDnH(MdlPartner obj)
      {
          MdlFirm Fmodel = new MdlFirm();
          MdlPartner model = new MdlPartner();
          ObjectParameter objParamOrgDocID = new ObjectParameter("OrgDocID", typeof(long));
          _dbFirms.usp_InsertFormDnHEntry(obj.OrgId, obj.FormDSubmissionDate,null, null,null,null,obj.EnterByUser_ID,objParamOrgDocID);
        //this is for organization id
            Fmodel.ExistingOrgDocID = obj.OrgId;
          Fmodel.OrgName = obj.OrgName;
            //new form H orgdoc_id
          Fmodel.OrgDocID = Convert.ToInt64(objParamOrgDocID.Value);

          return Fmodel;
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

    }
}
