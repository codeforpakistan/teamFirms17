﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectFirms01.Reports
{
    public partial class RptGetOrganizationsBwDates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                RpvOrgs.LocalReport.Refresh();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}