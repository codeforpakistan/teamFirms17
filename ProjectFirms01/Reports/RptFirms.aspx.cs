using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace ProjectFirms01.Reports
{
    public partial class RptFirms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //ReportDataSource rds = new ReportDataSource()
                //RpvFirms.LocalReport.DataSources.Clear();
                //RpvFirms.LocalReport.DataSources.Add(rds); 
            }
        }
    }
}