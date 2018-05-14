using System;
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
            PopulateNumOfRoundsDDL();
        }

        private void PopulateNumOfRoundsDDL()
        {
            ListItem li = new ListItem();
            li.Text = "--";
            li.Value = "0";
            ddlNumberOfRounds.Items.Add(li);
            for (int i = 1; i <= 52; i++)
            {
                ListItem li2 = new ListItem();
                li2.Text = i.ToString();
                li2.Value = i.ToString();
                ddlNumberOfRounds.Items.Add(li2);
            }
        }

        protected void btnDraftSetup_Click(object sender, EventArgs e)
        {
            // TODO Add Custom Validator to ddl.
            GlobalVariables.NumberOfRounds = Convert.ToInt32(ddlNumberOfRounds.SelectedValue);

            Response.Redirect("~/Draft.aspx");
        }
    }
}