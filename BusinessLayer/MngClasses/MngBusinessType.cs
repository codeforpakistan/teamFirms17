using BusinessLayer.MdlClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MngClasses
{
   public class MngBusinessType
    {
      private readonly dbFirmsEntities _dbFirms;
        public MngBusinessType()
        {

            if (_dbFirms == null)
            {
                _dbFirms = new dbFirmsEntities();
            }
        }

        //AllOrgTypes

        public List<Dropdownlist> AllOrgTypes(int Id)
        {
            var query = _dbFirms.ORGTYPEs.ToList();
            List<Dropdownlist> list = new List<Dropdownlist>();
            foreach (var item in query)
            {
                list.Add(new Dropdownlist()
                {
                    Value = item.OrgTypeID,
                    Label = item.OrgTypeName,
                    Selected = item.OrgTypeID == Id ? true : false

                });
            }
            return list;

        }
       //old one for adding bussiness type
        //public void AddNewBusinessType(MdlBusinessType obj)
        //{
        //    _dbFirms.usp_InsertNewBusinessType(obj.BusinessTypeName, obj.EnteredByUser_ID);
        //}
       
        public MdlBusinessType EditBussinessType(int id)
        {
            var query = from a in _dbFirms.BUSINESSTYPEs
                                              
                        join ac in _dbFirms.ORGTYPEs on a.OfType equals ac.OrgTypeID                       
                          where a.BusinessTypeID == id
                        select new
                        {
                            a.BusinessTypeID,
                            a.BusinessTypeName,
                            ac.OrgTypeID,
                            ac.OrgTypeName,
                            a.IsActive

                        };

            MdlBusinessType model = new MdlBusinessType();

            foreach (var item in query)
            {
                model.BusinessTypeID = item.BusinessTypeID;
                model.BusinessTypeName = item.BusinessTypeName;
                model.OrgTypeID = item.OrgTypeID;
                model.IsActive = item.IsActive;
                model.OrgTypeName = item.OrgTypeName;
            }
                    
            return model;
        }
        public void UpdateBussinessTyep(MdlBusinessType obj)
        {
            try
            {
                BUSINESSTYPE item = _dbFirms.BUSINESSTYPEs.Where(x => x.BusinessTypeID == obj.BusinessTypeID).SingleOrDefault();
                item.BusinessTypeName = obj.BusinessTypeName;
                item.IsActive = obj.IsActive;
                item.UpdateByUser_ID = obj.EnteredByUser_ID;
                item.UpdateTime = DateTime.Now;
                item.OfType = obj.OrgTypeID;
                _dbFirms.SaveChanges();
            }
            catch
            {

            }

        }

        public void AddNewBusinessType(MdlBusinessType obj)
        {
            var t = new BUSINESSTYPE
            {
                BusinessTypeName = obj.BusinessTypeName,
                IsActive=true,
                EnteredByUser_ID=obj.EnteredByUser_ID,
                EntryTime=DateTime.Now,
                OfType = obj.OrgTypeID

            };

            _dbFirms.BUSINESSTYPEs.Add(t);
            _dbFirms.SaveChanges();
        }


      



       //old one code

        //public List<MdlBusinessType> GetAllBusinessTypes()
        //{
        //    return _dbFirms.BUSINESSTYPEs.Select(n => new MdlBusinessType { BusinessTypeID = n.BusinessTypeID, BusinessTypeName = n.BusinessTypeName, EnteredByUser_ID = n.EnteredByUser_ID,IsActive=n.IsActive }).ToList();

        //}

       //new one code
        public List<MdlBusinessType> GetAllBusinessTypes()
        {
            var query = from a in _dbFirms.BUSINESSTYPEs

                        join ac in _dbFirms.ORGTYPEs on a.OfType equals ac.OrgTypeID
                        join u in _dbFirms.USERs on a.EnteredByUser_ID equals u.UserID

                        select new
                        {
                            a.BusinessTypeID,
                            a.BusinessTypeName,
                            ac.OrgTypeID,
                            ac.OrgTypeName,
                            a.IsActive,
                            a.EnteredByUser_ID,
                            u.UserName

                        };

            List<MdlBusinessType> list = new List<MdlBusinessType>();
            foreach (var item in query)
            {
                list.Add(new MdlBusinessType()
                {
                    BusinessTypeID = item.BusinessTypeID,
                    BusinessTypeName = item.BusinessTypeName,
                    OrgTypeID = item.OrgTypeID,
                    IsActive = item.IsActive,
                    OrgTypeName = item.OrgTypeName,
                    UserName=item.UserName

                });
            }


            return list;
        }
      
    }
}
