using BusinessLayer.MdlClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MngClasses
{
    public class MngDocument
    {

        # region crud ops

        private readonly dbFirmsEntities _dbFirms;
        public MngDocument()
        {

            if (_dbFirms == null)
            {
                _dbFirms = new dbFirmsEntities();
            }
        }

        public void AddNewDocument(MdlDocument obj)
        {
            _dbFirms.usp_InsertNewDocument(obj.DocumentName,obj.EnteredByUser_ID);

        }
        public MdlDocument EditDocument(int id)
        {
            DOCUMENT item = _dbFirms.DOCUMENTs.Where(x => x.DocumentID == id).SingleOrDefault();
            MdlDocument model = new MdlDocument();
            model.DocumentID = item.DocumentID;
            model.DocumentName = item.DocumentName;
            model.IsActive = item.IsActive;
            return model;
        }
        public void UpdateDocument(MdlDocument obj)
        {
            _dbFirms.usp_UpdateDocument(obj.DocumentID, obj.DocumentName, obj.UpdateByUser_ID);
        }

        public List<MdlDocument> GetAllDocuments()
        {


          //return  _dbFirms.DOCUMENTs.Select(n => new MdlDocument { 
          //    DocumentID = n.DocumentID, DocumentName = n.DocumentName, IsActive = n.IsActive,
          //    EnteredByUser_ID = n.EnteredByUser_ID,UpdateByUser_ID=n.UpdateByUser_ID.Value 
          //}).ToList();


          var query = _dbFirms.DOCUMENTs.ToList();
          var list = new List<MdlDocument>();
            foreach (var item in query)
            {
                list.Add(new MdlDocument
                    {
                        DocumentID=item.DocumentID,
                        DocumentName=item.DocumentName,
                        IsActive=item.IsActive,
                        EnteredByUser_ID=item.EnteredByUser_ID,
                        EntryTime=item.EntryTime
                    });
            }
            return list;


        }




        public void DelteDocType(int id)
        {

            var query = _dbFirms.DOCUMENTs.FirstOrDefault(g => g.DocumentID == id);
            if (query != null)
            {
               _dbFirms.DOCUMENTs.Remove(query);
                _dbFirms.SaveChanges();
            }
        }
        # endregion


    }
}
