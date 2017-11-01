using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MdlClasses
{
    public class MdlDocument
    {

        public int DocumentID { get; set; }
        public string DocumentName { get; set; }
        public bool IsActive { get; set; }
        public int EnteredByUser_ID { get; set; }
        public DateTime EntryTime { get; set; }
        public int UpdateByUser_ID { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
