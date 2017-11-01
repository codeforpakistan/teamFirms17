using BusinessLayer.MdlClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MngClasses
{
   public  class MngPDFReport
    {
        private readonly dbFirmsEntities _dbFirms;
        public MngPDFReport()
        {

            if (_dbFirms == null)
            {
                _dbFirms = new dbFirmsEntities();
            }
        }

        public List<MdlFirm> GetOrganizationNameUsingFileNo(string fileNo)
        {
            var query = _dbFirms.usp_GetOrganizationNameUsingFileNo(fileNo,true);           

            List<MdlFirm> list = new List<MdlFirm>();

            foreach (var item1 in query)
            { 
                list.Add(new MdlFirm(){
               OrgRegNo = item1.FileNo,
               OrgName = item1.OrgName
            });
            }

            return list;

        }

        public List<MdlADDRESSS> GetAddressesofOrgnaizationUsingFileNo(string fileNo)
        {
            var query = _dbFirms.usp_GetAddressesofOrgnaizationUsingFileNo(fileNo, true);

            List<MdlADDRESSS> list = new List<MdlADDRESSS>();

            foreach (var item1 in query)
            { 
                list.Add(new MdlADDRESSS()
                {
                 OrgRegNo = item1.OrgRegNo,
                AdressType_ID  = item1.AdressType_ID,
                AdressDetails=item1.AdressDetails
               });

            }

            return list;

        }


        public List<MdlPartner> GetPartnersofOrganizationUsingFileNo(string fileNo)
        {
            var query = _dbFirms.usp_GetPartnersofOrganizationUsingFileNo(fileNo, true);

            List<MdlPartner> list = new List<MdlPartner>();

            foreach (var item1 in query)
            {
                list.Add(new MdlPartner()
                {
                    OrgRegNo = item1.OrgRegNo,
                    PartnerName = item1.PartnerName,
                    PartnerShare = item1.PartnerShare,
                    PartnerCNIC = item1.NIC,
                    PartnerAddress = item1.PartnerAddress,
                    PartnerContactNo = item1.PartnerContactNo,
                    PartnerMobileNo = item1.PartnerMobileNo,
                    IsActive = item1.isActive

                });

            }

            return list;

        }


        public List<MdlWitness> GetWitnessesofOrganizationUsingFileNo(string fileNo)
        {
            var query = _dbFirms.usp_GetWitnessesofOrganizationUsingFileNo(fileNo, true);

            List<MdlWitness> list = new List<MdlWitness>();

            foreach (var item1 in query)
            {
                list.Add(new MdlWitness()
                {
                    WitnessName = item1.WitnessName,
                    OrgRegNo = item1.OrgRegNo
                   

                });

            }

            return list;

        }
    }
}
