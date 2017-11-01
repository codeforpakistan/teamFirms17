using BusinessLayer.MdlClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MngClasses
{
  public  class MngWitness
    {
        private readonly dbFirmsEntities _dbFirms;
        public MngWitness()
        {

            if (_dbFirms == null)
            {
                _dbFirms = new dbFirmsEntities();
            }
        }


      public List<MdlWitness> GetAllWitnessList()
        {
            var query= _dbFirms.WITNESSes.ToList();
            var list =new  List<MdlWitness>();
            foreach (var obj in query)
          {
              list.Add(new MdlWitness()
              {
                  WitnessID = obj.WitnessID,
                 WitnessName= obj.WitnessName,
                WitnessCNIC=  obj.WitnessCNIC,
                 WitnessONIC= obj.WitnessONIC,
                WitnessAddress=  obj.WitnessAddress,
                WitnessContactNo=  obj.WitnessContactNo,
                  WitnessMobileNo = obj.WitnessMobileNo,
                 WitnessCitizenNo= obj.WitnessCitizenNo,
                WitnessPassportNo=  obj.WitnessPassportNo,
                  OrgDoc_ID=obj.OrgDoc_ID,
                 EnterByUser_ID= obj.EnterByUser_ID ,
                 EntryDate=obj.EntryDate.Date
              });
          }
            return list;
        }
      public List<MdlWitness> GetAllWitnessListForSociety()
        {
            var query = _dbFirms.usp_GetWitnessesofOrgType(2);
            var list =new  List<MdlWitness>();
            foreach (var obj in query)
          {
              list.Add(new MdlWitness()
              {
                  WitnessID = obj.WitnessID,
                 WitnessName= obj.WitnessName,
                WitnessCNIC=  obj.WitnessCNIC,
                 WitnessONIC= obj.WitnessONIC,
                WitnessAddress=  obj.WitnessAddress,
                WitnessContactNo=  obj.WitnessContactNo,
                  WitnessMobileNo = obj.WitnessMobileNo,
                 WitnessCitizenNo= obj.WitnessCitizenNo,
                WitnessPassportNo=  obj.WitnessPassportNo,
                  OrgDoc_ID=obj.OrgDoc_ID,
                 EnterByUser_ID= obj.EnterByUser_ID ,
                 EntryDate=obj.EntryDate.Date
              });
          }
            return list;
        }
      public List<MdlWitness> GetAllWitnessListForMadrassa()
      {
          var query = _dbFirms.usp_GetWitnessesofOrgType(3);
          var list = new List<MdlWitness>();
          foreach (var obj in query)
          {
              list.Add(new MdlWitness()
              {
                  WitnessID = obj.WitnessID,
                  WitnessName = obj.WitnessName,
                  WitnessCNIC = obj.WitnessCNIC,
                  WitnessONIC = obj.WitnessONIC,
                  WitnessAddress = obj.WitnessAddress,
                  WitnessContactNo = obj.WitnessContactNo,
                  WitnessMobileNo = obj.WitnessMobileNo,
                  WitnessCitizenNo = obj.WitnessCitizenNo,
                  WitnessPassportNo = obj.WitnessPassportNo,
                  OrgDoc_ID = obj.OrgDoc_ID,
                  EnterByUser_ID = obj.EnterByUser_ID,
                  EntryDate = obj.EntryDate.Date,
                  IsActive=obj.IsActive
              });
          }
          return list;
      }
      public MdlWitness  GetWitnessInfoForEdit(long id)
      {
          var obj = _dbFirms.WITNESSes.Where(n=>n.WitnessID==id).SingleOrDefault();
          var list = new  MdlWitness();
       
                 list.WitnessID = obj.WitnessID;
                  list.WitnessName = obj.WitnessName;
                  list.WitnessCNIC = obj.WitnessCNIC;
                  list.WitnessONIC = obj.WitnessONIC;
                  list.WitnessAddress = obj.WitnessAddress;
                  list.WitnessContactNo = obj.WitnessContactNo;
                  list.WitnessMobileNo = obj.WitnessMobileNo;
                  list.WitnessCitizenNo = obj.WitnessCitizenNo;
                  list.WitnessPassportNo = obj.WitnessPassportNo;
                  list.OrgDoc_ID = obj.OrgDoc_ID;
                  list.EnterByUser_ID = obj.EnterByUser_ID;
                  list.EntryDate = obj.EntryDate.Date;
            
           
          return list;
      }
      public void AddNewWitness(MdlWitness obj)
        {
            _dbFirms.usp_InsertNewWitness(
                obj.WitnessName,
                obj.WitnessCNIC,
                obj.WitnessONIC,
                obj.WitnessAddress,
                obj.WitnessContactNo,
                obj.WitnessMobileNo,
                obj.WitnessCitizenNo,
                obj.WitnessPassportNo,
                obj.OrgDoc_ID,
                obj.EnterByUser_ID              
                
                );


        }

      public void UpdateWitness(MdlWitness obj)
      {
          _dbFirms.usp_UpdateWitness(
              obj.WitnessID,
              obj.WitnessName,
              obj.WitnessCNIC,
              obj.WitnessONIC,
              obj.WitnessAddress,
              obj.WitnessContactNo,
              obj.WitnessMobileNo,
              obj.WitnessCitizenNo,
              obj.WitnessPassportNo,
              obj.OrgDoc_ID,
              obj.EnterByUser_ID

              );


      }


      public List<MdlWitness> OrgWitnessList(long Id)
      {
          // long id = 11;
          var query = _dbFirms.WITNESSes.Where(n => n.OrgDoc_ID == Id).ToList();
          List<MdlWitness> list = new List<MdlWitness>();
          foreach (var item in query)
          {
              list.Add(new MdlWitness()
              {
                  WitnessName = item.WitnessName,
                  WitnessCNIC = item.WitnessCNIC,
                 WitnessAddress = item.WitnessAddress

                  // Selected = item.OrgDoc_ID == id ? true : false

              });
          }
          return list;

      }
    }
}
