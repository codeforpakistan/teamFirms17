using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.MdlClasses;
using BusinessLayer.MngClasses;

namespace BusinessLayer.MngClasses
{
    public class MngInfo
    {
        private readonly dbFirmsEntities _dbFirms;
        public MngInfo()
        {

            if (_dbFirms == null)
            {
                _dbFirms = new dbFirmsEntities();
            }
        }

        public List<Dropdownlist> GetAllOrgIDNName(long id)
        {
            var query = _dbFirms.usp_GetAllFileNames(0) ;
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

        public List<Dropdownlist> GetAllBankIDNNames(long bankid)
        {
            var query = _dbFirms.usp_GetAllBAnks();
            List<Dropdownlist> list = new List<Dropdownlist>();
            foreach (var item in query)
            {
                list.Add(new Dropdownlist()
                {
                    Value = item.BankID,
                    Label = item.BankName,
                    OptionalLabel = item.BankName,
                    Selected = item.BankID == bankid ? true : false

                });
            }
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

        # region BankAccount
        public void AddNewBankAcctofOrg(MdlBankAccount obj)
        {
            _dbFirms.usp_InsertBankAccountofOrg(obj.AccountTitle,obj.Bank_ID,obj.BranchCode,obj.CreationDate,obj.EnteredByUser_ID,null,true,obj.Org_ID);
        }

        public void UpdateBankAccount(MdlBankAccount obj)
        {
            _dbFirms.usp_UpdateBAnkAccntofOrg(obj.BankAccountID, obj.AccountTitle, obj.Bank_ID, obj.BranchCode, obj.CreationDate, obj.ModifyByUser_ID,obj.IsActive,null,obj.Org_ID);
        }

        public MdlBankAccount GetBankAccounttoEdit(long id)
        {
            var obj = _dbFirms.BACCOUNTS.Where(n => n.BankAccountID == id).SingleOrDefault();
            var list = new MdlBankAccount();
            list.BankAccountID = obj.BankAccountID;
            list.Bank_ID = obj.Bank_ID;
            list.BranchCode = obj.BranchCode;
            list.CreationDate = obj.CreationDate;
            list.AccountTitle = obj.AccountTitle;           
            list.Org_ID = obj.Org_ID;
            list.IsActive = obj.IsActive.Value;
            return list;
        }

        public List<MdlBankAccount> GetAllBankAccountsofOrg(long orgid)
        {
            var query = _dbFirms.usp_GetBankAccountsofOrg(orgid);
            List<MdlBankAccount> list = new List<MdlBankAccount>();
            foreach (var item in query)
            {

                list.Add(new MdlBankAccount()
                {
                    BankAccountID = item.BankAccountID,
                    AccountTitle = item.AccountTitle,
                    Bank_ID = item.Bank_ID,
                     BranchCode = item.BranchCode,
                      CreationDate = item.CreationDate,
                       EnteredByUser_ID = item.EnteredByUser_ID,
                        EntryDate = item.EntryDate,
                         Org_ID = item.OrganizationID,
                           BankName = item.BankName,
                           FileNo = item.OrgRegNo,
                            EntryDateString = item.EntryDate.ToShortDateString(),
                            IsActive=item.IsActive.Value
                });
            }
            return list;
        }

        # endregion

        # region association
        public void AddNewAssociationofOrg(MdlAssociation obj)
        {
          _dbFirms.usp_InsertAssociationofOrg(obj.AssociationType, obj.AssociationTitle, obj.AssociationDate,"0", obj.ExpiryDate, obj.EnteredByUser_ID, obj.IsActive,obj.Org_ID);
        }

        public void UpdateAssociationofOrg(MdlAssociation obj)
        {
            _dbFirms.usp_UpdateAssociationInfo(obj.AssociationID, obj.AssociationType, obj.AssociationTitle, obj.AssociationDate, "0", obj.ExpiryDate, obj.ModifyByUser_ID, obj.IsActive, obj.IsActiveDate, obj.Org_ID);
        }

        public MdlAssociation GetAssociationtoEdit(long id)
        {
            var obj = _dbFirms.ASSOCIATIONs.Where(n => n.AssociationID == id).SingleOrDefault();

            var list = new MdlAssociation();
            list.AssociationID = obj.AssociationID;
            list.AssociationTitle = obj.AssociationTitle;
            list.AssociationType = obj.AssociationType;
            list.AssociationDate = obj.AssociationDate;
            list.Duration = obj.Duration;
            list.ExpiryDate = obj.ExpiryDate.Value;
            list.Org_ID = obj.Org_ID;
            list.IsActive = obj.IsActive.Value;

            return list;
        }

        public List<MdlAssociation> GetAllAssociationsofOrg(long orgid)
        {
            var query = _dbFirms.usp_GetAllAssociationsofOrg(orgid);
            List<MdlAssociation> list = new List<MdlAssociation>();
            foreach (var item in query)
            {
                list.Add(new MdlAssociation()
                {
                   AssociationID = item.AssociationID,
                    AssociationTitle = item.AssociationTitle,
                    AssociationDate = item.AssociationDate,
                     ExpiryDate = item.ExpiryDate.Value,
                     FileNo = item.OrgRegNo,
                     IsActive = item.IsActive.Value
                });
            }
            return list;
        }

        # endregion

        # region assets

        public void AddNewAssetofOrg(MdlAsset obj)
        {
            _dbFirms.usp_InsertAssetofOrg(obj.AssetName, 0, obj.AssetValue, obj.PurchaseDate, obj.EnterByUser_ID, obj.Org_ID);
        }

        public void UpdateAssetofOrg(MdlAsset obj)
        {
            _dbFirms.usp_UpdateAssetofOrg(obj.AssetID, obj.AssetName, 0, obj.AssetValue, obj.PurchaseDate, obj.ModifyByUser_ID, obj.IsActive,null, obj.Org_ID);
        }

        public MdlAsset GetAssettoEdit(long id)
        {
            var obj = _dbFirms.ASSETs.Where(n => n.AssetID == id).SingleOrDefault();

            var list = new MdlAsset();
            list.AssetID = obj.AssetID;
            list.AssetName = obj.AssetName;
            list.AssetType = obj.AssetType;
            list.AssetValue = obj.AssetValue;
            list.PurchaseDate = obj.PurchaseDate;
            list.IsActive = obj.IsActive.Value;
            list.Org_ID = obj.Org_ID;
            return list;
        }
        public List<MdlAsset> GetAllAssetsofOrg(long orgid)
        {
            var query = _dbFirms.usp_GetAssetsofanOrg(orgid);
            List<MdlAsset> list = new List<MdlAsset>();
            foreach (var item in query)
            {
                list.Add(new MdlAsset()
                {
                    AssetID = item.AssetID,
                    AssetName = item.AssetName,
                    AssetValue = item.AssetValue,
                    PurchaseDate = item.PurchaseDate,
                    Org_ID = item.OrganizationID,
                    FileNo = item.OrgRegNo,
                    IsActive = item.IsActive.Value
                });
            }
            return list;
        }

        #endregion

        # region funds

        public void AddNewFundSourceofOrg(MdlFund obj)
        {
            _dbFirms.usp_InsertFundInfoofOrg(obj.FundSourceName, obj.FundSourceType, obj.TransferMeans, obj.TransferAmount, obj.EnteredByUser_ID, obj.IsActive, obj.Org_ID,obj.RcvYear);
        }

        public void UpdateFundSource(MdlFund obj)
        {
            _dbFirms.usp_UpdateFundSourceInfo(obj.FundSourceID, obj.FundSourceName, obj.FundSourceType, obj.TransferMeans, obj.TransferAmount, obj.ModifyByUser_ID, obj.IsActive, obj.IsActiveDate, obj.Org_ID,obj.RcvYear);
        }

        public MdlFund GetFundtoEdit(long id)
        {
            var obj = _dbFirms.FUNDs.Where(n => n.FundSourceID == id).SingleOrDefault();

            var list = new MdlFund();
            list.FundSourceID = obj.FundSourceID;
            list.FundSourceName = obj.FundSourceName;
            list.FundSourceType = obj.FundSourceType;
            list.TransferAmount = obj.TransferAmount;
            list.TransferMeans = obj.TransferMeans;
            list.Org_ID = obj.Org_ID;
            list.IsActive = obj.IsActive.Value;
            return list;
        }      

        public List<MdlFund> GetAllFundsofOrg(long orgid)
        {
            var query = _dbFirms.usp_GetFundSourcesofOrg(orgid);
            List<MdlFund> list = new List<MdlFund>();
            foreach (var item in query)
            {
                list.Add(new MdlFund()
                {
                    FundSourceID = item.FundSourceID,
                    FundSourceName = item.FundSourceName,
                    TransferMeans = item.TransferMeans,
                    TransferAmount = item.TransferAmount,
                    FileNo = item.OrgRegNo,
                    IsActive = item.IsActive.Value
                 


                });
            }
            return list;
        }

        # endregion

        # region staff

        public void AddNewStaffofOrg(MdlStaff obj)
        {
            _dbFirms.usp_InserNewStaff(obj.StaffType, obj.Designation_ID, obj.Name, obj.CNIC, obj.ContactNo, obj.Salary, obj.EnteredByUser_ID, obj.IsActive, obj.Org_ID);
        }

        public void UpdateStaffofOrg(MdlStaff obj)
        {
            _dbFirms.usp_UpdateStaff(obj.StaffID,obj.StaffType,obj.Designation_ID,obj.Name,obj.CNIC,obj.ContactNo,obj.Salary,obj.ModifyByUser_ID,obj.IsActive,obj.IsActiveDate, obj.Org_ID);
        }

        public List<MdlStaff> GetAllStaffofOrg(long orgid)
        {
            var query = _dbFirms.usp_GetStaffMembersofOrg4(orgid);
            List<MdlStaff> list = new List<MdlStaff>();
            foreach (var item in query)
            {
                list.Add(new MdlStaff()
                {
                     StaffID = item.StaffID,
                      Name = item.Name,
                       CNIC = item.CNIC,
                        DesignationName = item.DesignationName,
                         Salary = item.Salary,
                          ContactNo = item.ContactNo,
                          FileNo = item.FileNo,
                          IsActive = item.IsActive.Value
                           
                });
            }
            return list;
        }

        public MdlStaff GetStafftoEdit(long id)
        {
            var obj = _dbFirms.STAFFs.Where(n => n.StaffID == id).SingleOrDefault();

            var list = new MdlStaff();
            list.StaffID = obj.StaffID;
            list.Name = obj.Name;
            list.StaffType = obj.StaffType;
            list.Designation_ID = obj.Designation_ID;
            list.ContactNo = obj.ContactNo;
            list.CNIC = obj.CNIC;
            list.Salary = obj.Salary;            
            list.Org_ID = obj.Org_ID;
            list.IsActive = obj.IsActive.Value;
            return list;
        } 
      
        # endregion

        # region Project
        public void AddNewSProjectofOrg(MdlProject obj)
        {
            _dbFirms.usp_InsertNewProject(obj.ProjectTitle,obj.StartDate,obj.Org_ID,obj.IsComplete, obj.EnteredByUser_ID);
        }

        public void UpdateProjectofOrg(MdlProject obj)
        {
            _dbFirms.usp_UpdateProject(obj.ProjectID,obj.ProjectTitle,obj.StartDate,obj.Org_ID,obj.IsComplete, obj.ModifyByUser_ID, obj.IsActive, obj.IsActiveDate);
        }


        public MdlProject GetProjecttoEdit(long id)
        {
            var obj = _dbFirms.PROJECTs.Where(n => n.ProjectID == id).SingleOrDefault();
            var list = new MdlProject();
            list.ProjectID = obj.ProjectID;
            list.ProjectTitle = obj.ProjectTitle;
            list.StartDate = obj.StartDate.Value;
            list.IsComplete = obj.IsComplete;
            list.EnteredByUser_ID = obj.EnteredByUser_ID;
            list.IsActive = obj.IsActive.Value;
            return list;
        }
        public List<MdlProject> GetAllProjectsofOrg(long orgid)
        {
            var query = _dbFirms.usp_SelectAllProjectsofOrg(orgid);
            List<MdlProject> list = new List<MdlProject>();
            foreach (var item in query)
            {
                list.Add(new MdlProject()
                {
                     ProjectID = item.ProjectID,
                     ProjectTitle = item.ProjectTitle,
                     StartDate = item.StartDate.Value,
                     FileNo  = item.OrgRegNo,
                     IsComplete = item.IsComplete,
                     IsActive = item.IsActive.Value
                     
                      
                });
            }
            return list;
        }


        # endregion
    }
}
