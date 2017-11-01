using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
    public  class FirmsBaseModel
    {

        public List<MdlBusinessType> bussinesstypeslist = new List<MdlBusinessType>();
        public List<MdlADDRESSS> addresslist = new List<MdlADDRESSS>();
        public List<MdlPartner> partnerlist = new List<MdlPartner>();
        public List<MdlWitness> witnesslist = new List<MdlWitness>();
        public List<MdlFirm> firmsinfomdl = new List<MdlFirm>();
        //public MdlFirm firmsinfomdl = new MdlFirm();

    }
}
