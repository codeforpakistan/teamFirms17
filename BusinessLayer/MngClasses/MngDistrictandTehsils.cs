using BusinessLayer.MdlClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MngClasses
{
    public class MngDistrictandTehsils
    {
        private readonly dbFirmsEntities _dbFirms;
        public MngDistrictandTehsils()
        {

            if (_dbFirms == null)
            {
                _dbFirms = new dbFirmsEntities();
            }
        }

        public List<MdlDistrictandTehsils> GetAllDistrictsList()
        {
            var query = _dbFirms.DISTRICTs.ToList();
            var list = new List<MdlDistrictandTehsils>();
            foreach (var obj in query)
            {
                list.Add(new MdlDistrictandTehsils()
                {
                    DistrictID = obj.DistrictID,
                    DistrictName = obj.DistrictName,


                });
            }
            return list;
        }


     
        public List<MdlDistrictandTehsils> GetAllTehsilList()
        {
            var query = from o in _dbFirms.TEHSILs
                        join c in _dbFirms.DISTRICTs on o.District_ID equals c.DistrictID                        
                        select new
                        {
                            o.TehsilID,
                            o.TehsilName,
                            o.District_ID,
                            c.DistrictName
                        };
          //  var query = _dbFirms.TEHSILs.ToList();
            var list = new List<MdlDistrictandTehsils>();
            foreach (var obj in query)
            {
                list.Add(new MdlDistrictandTehsils()
                {
                    District_ID = obj.District_ID,
                    TehsilID = obj.TehsilID,
                    TehsilName=obj.TehsilName,
                    DistrictName=obj.DistrictName


                });
            }
            return list;
        }


        public void CreateDistrict(string DistrictName)
        {
            var t = new DISTRICT
           {
             DistrictName = DistrictName

            };

            _dbFirms.DISTRICTs.Add(t);
            _dbFirms.SaveChanges();
        }

        public void CreateTehsil(string TehsilName,int DistrictID)
        {
            var t = new TEHSIL
            {
                TehsilName = TehsilName,
                District_ID=DistrictID

            };

            _dbFirms.TEHSILs.Add(t);
            _dbFirms.SaveChanges();
        }

        public MdlDistrictandTehsils EditTehsil(int id)
        {
            TEHSIL item = _dbFirms.TEHSILs.Where(x => x.TehsilID == id).SingleOrDefault();
            MdlDistrictandTehsils model = new MdlDistrictandTehsils();
            model.DistrictID = item.District_ID;
            model.TehsilName = item.TehsilName;
            model.TehsilID = item.TehsilID;
            return model;
        }
        public MdlDistrictandTehsils EditDistrict(int id)
        {
            DISTRICT item = _dbFirms.DISTRICTs.Where(x => x.DistrictID == id).SingleOrDefault();
            MdlDistrictandTehsils model = new MdlDistrictandTehsils();
            model.DistrictID = item.DistrictID;
            model.DistrictName = item.DistrictName;            
            return model;
        }

        public void UpdateDistrict(string DistrictName,int DistrictID)
        {
            try
            {
                DISTRICT item = _dbFirms.DISTRICTs.Where(x => x.DistrictID == DistrictID).SingleOrDefault();
                item.DistrictName = DistrictName;
                _dbFirms.SaveChanges();
            }
            catch
            {

            }
                      
        }

        public void UpdateTehsil(string TehsilName, int DistrictID,int TeshilID)
        {
            try
            {
                TEHSIL item = _dbFirms.TEHSILs.Where(x => x.TehsilID == TeshilID).SingleOrDefault();
                item.District_ID = DistrictID;
                item.TehsilName = TehsilName;
                _dbFirms.SaveChanges();
            }
            catch
            {

            }

        }

        public List<Dropdownlist> GetAllDistrict(int Id)
        {
            var query = _dbFirms.DISTRICTs.ToList();
            List<Dropdownlist> list = new List<Dropdownlist>();
            foreach (var item in query)
            {
                list.Add(new Dropdownlist()
                {
                    Value = item.DistrictID,
                    Label = item.DistrictName,
                    Selected=item.DistrictID==Id?true:false

                });
            }
            return list;

        }


    }
}
