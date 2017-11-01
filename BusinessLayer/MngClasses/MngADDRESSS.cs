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
   public class MngADDRESSS
    {
         private readonly dbFirmsEntities _dbFirms;
         public MngADDRESSS()
        {

            if (_dbFirms == null)
            {
                _dbFirms = new dbFirmsEntities();
            }
        }
         public List<Dropdownlist> GetAllDistrics(int id)
         {
             var query = _dbFirms.DISTRICTs.ToList();
             List<Dropdownlist> list = new List<Dropdownlist>();
             foreach (var item in query)
             {
                 list.Add(new Dropdownlist()
                 {
                     Value = item.DistrictID,
                     Label = item.DistrictName,
                     Selected = item.DistrictID == id ? true : false

                 });
             }
             return list;

         }
         public List<Dropdownlist> GetAllAddressType(int id)
         {
             var query = _dbFirms.ADRESSTYPEs.ToList();
             List<Dropdownlist> list = new List<Dropdownlist>();
             foreach (var item in query)
             {
                 list.Add(new Dropdownlist()
                 {
                     Value = item.AdressTypeID,
                     Label = item.AdressTypeName,
                     Selected = item.AdressTypeID == id ? true : false
                 });
             }
             return list;

         }

       //here we getting orgDoc_ID and as well as an orginzation name for showing to the user
       //but on backend we shall implementing only their OrgDocID for logic
         public List<Dropdownlist> GetAllOrgDocId(long id)
         {

            // long id = 11;
             var query = _dbFirms.usp_GetAllFileNames(1);
             //var query = _dbFirms.ORGDOCNAMEs.Where(x => x.IsActive == true).ToList();
             List<Dropdownlist> list = new List<Dropdownlist>();
             foreach (var item in query)
             {
                 list.Add(new Dropdownlist()
                 {
                     Value = item.OrgDoc_ID,
                     Label = item.OrgName,
                     OptionalLabel=item.OrgRegNo,
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
                     Value = item.OrgDoc_ID,
                     Label = item.OrgName,
                     OptionalLabel = item.OrgRegNo,
                     Selected = item.OrgDoc_ID == id ? true : false

                 });
             }
             return list;

         }

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
                     Value = item.OrgDoc_ID,
                     Label = item.OrgName,
                     OptionalLabel = item.OrgRegNo,
                     Selected = item.OrgDoc_ID == id ? true : false

                 });
             }
             return list;

         }
         public List<Dropdownlist> GetAllOrgDocIdForAlterAddress(long id)
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
                     Selected = item.OrganizationID == id ? true : false

                 });
             }
             return list;

         }


         public List<Dropdownlist> GetAllOrgDocIdForMadrassaAlterAddress(long id)
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

         public List<Dropdownlist> GetAllOrgDocIdForSocietyNGOAlterAddress(long id)
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


         public List<Dropdownlist> GetTehsilsByDistric(int id,int tehsil)
         {
             var query = _dbFirms.TEHSILs.Where(x => x.District_ID == id).ToList();
             List<Dropdownlist> list = new List<Dropdownlist>();
             foreach (var item in query)
             {
                 list.Add(new Dropdownlist()
                 {
                     Value = item.TehsilID,
                     Label = item.TehsilName,
                     Selected = item.TehsilID == tehsil ? true : false
                  //   Selected = row["CategoryTypeId"].ToString() == accountid.ToString().Trim() ? true : false

                 });
             }
             return list;

         }

       //throughh dataset
         public DataSet GetTehsilsByDistricbyDataset(int id)
         {
                DataTable dt = new DataTable();
             var query = _dbFirms.TEHSILs.Where(x => x.District_ID == id).ToList();
          
             //for each of your properties
             dt.Columns.Add("Label", typeof(string));
             dt.Columns.Add("Value", typeof(int));
             foreach (var entity in query)
             {
                 DataRow row = dt.NewRow();

                 //foreach of your properties
                 row["Value"] = entity.TehsilID;

                 row["Label"] = entity.TehsilName;
                 dt.Rows.Add(row);
             }

             DataSet ds = new DataSet();
             ds.Tables.Add(dt);
             return ds;
              
            
             
            
 
         }
      
         public void AddAddresss(MdlADDRESSS obj)
         { 

             _dbFirms.usp_InsertNewPrincipalAddress(
                obj.OrgDoc_ID,
                obj.AdressType_ID,
                obj.AdressDetails,
                obj.Tehsil_ID,
                obj.EnterByUser_ID

                 );
         }



         public void InsertFormBAlterAddress(MdlADDRESSS obj)
         {
             MdlADDRESSS model = new MdlADDRESSS();

             ObjectParameter objParamOrgDocID = new ObjectParameter("OrgDocID", typeof(long));


             _dbFirms.usp_InsertFormBAlterAdress(

                 obj.OrgId,
                 obj.OldAdressId,
                 obj.AdressType_ID,
                 obj.AdressDetails,
                 obj.Tehsil_ID,

                 obj.FormBSubmissionDate,
                 obj.FormBDocPath,
                 obj.NewFormHIssueNo,
                 obj.NewFormHIssueDate,
                 obj.NewFormHDocPath,
                 obj.EnterByUser_ID,
                 objParamOrgDocID


                 );
              

         }

         public List<MdlADDRESSS>  GetAllAddress()
         {
             var query = from a in _dbFirms.ADDRESSSes
                        // join d in _dbFirms.ORGDOCs on a.OrgDoc_ID equals d.OrgDocID
                         join org in _dbFirms.ORGDOCNAMEs on a.OrgDoc_ID equals org.OrgDoc_ID
                         join t in _dbFirms.TEHSILs on a.Tehsil_ID equals t.TehsilID
                         join at in _dbFirms.ADRESSTYPEs on a.AdressType_ID equals at.AdressTypeID
                      //   where d.Document_ID == 2
                         select new
                         {   a.AdressID,a.OrgDoc_ID,t.TehsilName,at.AdressTypeName,a.AdressDetails,a.IsActive,a.IsActiveDate,
                             org.OrgName
                             
                         };


            List<MdlADDRESSS> list = new List<MdlADDRESSS>();

            foreach (var item in query)
            {

                list.Add(new MdlADDRESSS()
                {
                    //list.FormADateString = Convert.ToDateTime(item.FormADate).ToShortDateString();                 
                    //list.FormGNo = item1.FormGNo;
                    //list.FirmStartDate = item1.FirmStartDate;                
                    //list.FirmStartDateString = Convert.ToDateTime(item1.FirmStartDate).ToShortDateString();
                    AdressID = item.AdressID,
                    OrgDoc_ID = item.OrgDoc_ID,
                    AdressTypeName = item.AdressTypeName,
                    AdressDetails = item.AdressDetails,
                    TehsilName = item.TehsilName,
                    IsActive=item.IsActive,
                    OrgName=item.OrgName
                   // IsActiveDate=item.IsActiveDate

                });
            }
             return list;

         }
       //this is old one code
         //public List<MdlADDRESSS> GetAllAddress()
         //{
             
         //    var query = _dbFirms.ADDRESSSes.ToList();

         // //   List<MdlADDRESSS> modleobj = new List<MdlADDRESSS>();
         //    //AdressID, OrgDoc_ID, AdressType_ID, AdressDetails, Tehsil_ID, EnterByUser_ID, EntryDate, ModifyByUser_ID, ModifyByDate, IsActive, IsActiveDate
         //    var list = new List<MdlADDRESSS>();
         //    foreach (var item in query)
         //    {
         //        list.Add(new MdlADDRESSS()
         //        {
                     
         //            AdressID=item.AdressID,
         //            OrgDoc_ID=item.OrgDoc_ID,
         //         AdressType_ID = item.AdressType_ID,
         //         AdressDetails = item.AdressDetails,
         //         Tehsil_ID = item.Tehsil_ID,
         //         EnterByUser_ID = item.EnterByUser_ID,
         //         //   EntryDateString = Convert.ToDateTime(item.EntryDate).ToShortDateString(),
         //        // ModifyByUser_ID = int.Parse(item.ModifyByUser_ID.ToString()),
         //        // ModifyByDate =DateTime.Parse(item.ModifyByDate.ToString()),
         //         IsActive = item.IsActive,
         //        // IsActiveDate =DateTime.Parse(item.IsActiveDate.ToString())            
                     
         //        });

         //    }
         //    return list;
         //}

         public List<MdlADDRESSS> GetAllAddress(int id)
         {

             var query = _dbFirms.usp_GetAddressesofOrgType(id);
             //   List<MdlADDRESSS> modleobj = new List<MdlADDRESSS>();
             //AdressID, OrgDoc_ID, AdressType_ID, AdressDetails, Tehsil_ID, EnterByUser_ID, EntryDate, ModifyByUser_ID, ModifyByDate, IsActive, IsActiveDate
             var list = new List<MdlADDRESSS>();
             foreach (var item in query)
             {
                 list.Add(new MdlADDRESSS()
                 {

                     AdressID = item.AdressID,
                     OrgDoc_ID = item.OrgDoc_ID,
                     AdressType_ID = item.AdressType_ID,
                     AdressDetails = item.AdressDetails,
                     Tehsil_ID = item.Tehsil_ID,
                     EnterByUser_ID = item.EnterByUser_ID,
                     AdressTypeName=item.AdressTypeName,
                     TehsilName=item.TehsilName,
                     OrgName=item.OrgName,
                     UserName=item.UserName,
                     //   EntryDateString = Convert.ToDateTime(item.EntryDate).ToShortDateString(),
                     // ModifyByUser_ID = int.Parse(item.ModifyByUser_ID.ToString()),
                     // ModifyByDate =DateTime.Parse(item.ModifyByDate.ToString()),
                     IsActive = item.IsActive,
                     // IsActiveDate =DateTime.Parse(item.IsActiveDate.ToString())            

                 });

             }
             return list;
         }


         //public List<MdlADDRESSS> GetAllAddressForSociety()
         //{

         //    var query = _dbFirms.usp_GetAddressesofOrgType(2);
         //    //   List<MdlADDRESSS> modleobj = new List<MdlADDRESSS>();
         //    //AdressID, OrgDoc_ID, AdressType_ID, AdressDetails, Tehsil_ID, EnterByUser_ID, EntryDate, ModifyByUser_ID, ModifyByDate, IsActive, IsActiveDate
         //    var list = new List<MdlADDRESSS>();
         //    foreach (var item in query)
         //    {
         //        list.Add(new MdlADDRESSS()
         //        {
         //            AdressID = item.AdressID,
         //            OrgDoc_ID = item.OrgDoc_ID,
         //            AdressType_ID = item.AdressType_ID,
         //            AdressDetails = item.AdressDetails,
         //            Tehsil_ID = item.Tehsil_ID,
         //            EnterByUser_ID = item.EnterByUser_ID,                   
         //            IsActive = item.IsActive,
                             
         //        });

         //    }
         //    return list;
         //}
         public List<MdlADDRESSS> OrgAddressList(long Id)
         {
 
             var query = from o in _dbFirms.ADDRESSSes
                          join c in _dbFirms.ADRESSTYPEs on o.AdressType_ID equals c.AdressTypeID
                          where o.OrgDoc_ID == Id
                         select new
                         {
                             o.AdressType_ID,
                             o.AdressDetails,
                             c.AdressTypeName                            

                         };
             //Old one query
           //  var query = _dbFirms.ADDRESSSes.Where(n => n.OrgDoc_ID == Id).ToList();
             List<MdlADDRESSS> list = new List<MdlADDRESSS>();
             foreach (var item in query)
             {
                 list.Add(new MdlADDRESSS()
                 {
                     AdressType_ID = item.AdressType_ID,
                     AdressDetails = item.AdressDetails,
                    AdressTypeName=item.AdressTypeName

                     // Selected = item.OrgDoc_ID == id ? true : false

                 });
             }
             return list;

         } 
       public List<MdlADDRESSS> OrgAddressAlterList(long Id)
         {

             int ID = Convert.ToInt32(Id);
             var query = _dbFirms.usp_GetPrimaryAdressIDofanOrg(ID);
             //Old one query
           //  var query = _dbFirms.ADDRESSSes.Where(n => n.OrgDoc_ID == Id).ToList();
             List<MdlADDRESSS> list = new List<MdlADDRESSS>();
             foreach (var item in query)
             {
                 list.Add(new MdlADDRESSS()
                 {
                     AdressID = item.AdressID,
                     AdressDetails = item.AdressDetails,
                  //  AdressTypeName=item.AdressTypeName

                     // Selected = item.OrgDoc_ID == id ? true : false

                 });
             }
             return list;

         }
         public MdlADDRESSS EditADDRESSS(int id)
         {
            // ADDRESSS  item = _dbFirms.ADDRESSSes.Where(x => x.AdressID == id).SingleOrDefault();
             var query = _dbFirms.usp_GetAddresssForEdit(id);
             MdlADDRESSS model = new MdlADDRESSS();

             foreach (var item in query)
             {
                 model.AdressID = item.AdressID;
                 model.OrgDoc_ID = item.OrgDoc_ID;
                 model.AdressType_ID = item.AdressType_ID;
                 model.AdressDetails = item.AdressDetails;
                 model.Tehsil_ID = item.Tehsil_ID;
                 model.Distric_ID =Convert.ToInt32(item.Distric_ID);
                 //  model.Distric_ID=item.AdressType_ID
                 // model.EnterByUser_ID = item.EnterByUser_ID;
                 //  model.EntryDate = item.EntryDate;
                 // model.ModifyByUser_ID = int.Parse(item.ModifyByUser_ID.ToString());
                 //  model.ModifyByDate =DateTime.Parse(item.ModifyByDate.ToString());
                 model.IsActive = item.IsActive;
             }
                 // model.IsActiveDate =Convert.ToDateTime(item.IsActiveDate.ToString());         
             return model;
         }

       public void UpdateAddress(MdlADDRESSS obj)
         {
             _dbFirms.usp_UpdatePrincipalAddress(obj.AdressID, obj.OrgDoc_ID, obj.AdressType_ID, obj.AdressDetails, obj.Tehsil_ID, obj.ModifyByUser_ID);
         }



    }
}
