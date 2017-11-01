using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
  public  class MdlDistrictandTehsils
    {
      public int DistrictID {get;set;}
      public string DistrictName { get; set; }
      public int TehsilID { get; set; } 
      public string TehsilName { get; set; }
      public int District_ID { get; set; }

      public List<Dropdownlist> GetAllDistrictsDrp = new List<Dropdownlist>();
      public List<MdlDistrictandTehsils> TehsilList = new List<MdlDistrictandTehsils>();
      public List<MdlDistrictandTehsils> DistrictList = new List<MdlDistrictandTehsils>();
    }
}
