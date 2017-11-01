using BusinessLayer.MdlClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MngClasses
{
   public class MngOrgType
    {
        private readonly dbFirmsEntities _dbFirms;
        public MngOrgType()
        {

            if (_dbFirms == null)
            {
                _dbFirms = new dbFirmsEntities();
            }
        }


       public List<MdlOrgType> GetAllOrgTypes()
        {
         //  return _dbFirms.ORGTYPEs.Select(n => new MdlOrgType { OrgTypeID = n.OrgTypeID, OrgTypeName = n.OrgTypeName }).ToList();
            var query = _dbFirms.ORGTYPEs.ToList();
            List<MdlOrgType> modleobj = new List<MdlOrgType>();

            var list = new List<MdlOrgType>();
            foreach (var item in query)
            {
                list.Add(new MdlOrgType()
                {
                    OrgTypeID = item.OrgTypeID,
                    OrgTypeName = item.OrgTypeName,
                    IsActive = item.IsActive,
                    EnteredByUser_ID = item.EnteredByUser_ID,
                    EntryTime = item.EntryTime,
                    UpdateByUser_ID = Convert.ToInt16(item.UpdateByUser_ID),
                    UpdateTime =Convert.ToDateTime(item.UpdateTime)
                });

            }
            return list;
        }
        public void AddNewOrgType(MdlOrgType obj)
        {
            _dbFirms.usp_InsertNewOrgType(obj.OrgTypeName, obj.EnteredByUser_ID.Value);          

        }

       public MdlOrgType EditOrgType(int id)
        {
            ORGTYPE item = _dbFirms.ORGTYPEs.Where(x => x.OrgTypeID == id).SingleOrDefault();
            MdlOrgType model = new MdlOrgType();
            model.OrgTypeID = item.OrgTypeID;
            model.OrgTypeName = item.OrgTypeName;
            model.IsActive = item.IsActive;
            return model;
          }

       public void UpdateOrgType(MdlOrgType obj)
       {
           _dbFirms.usp_UpdateOrgType(obj.OrgTypeID,obj.OrgTypeName, obj.EnteredByUser_ID.Value);   
       }
      


    }
}
