﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DraftPartyApplication
{
    public partial class DraftSetup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = GlobalVariables.TeamIdList;
            Label2.Text = GlobalVariables.TeamNameList;

        }
    }
}