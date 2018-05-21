using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DraftPartyApplication
{
    public partial class LeagueSetup : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Session.Abandon();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateNumOfTeamsDDL();
        }

        private void PopulateNumOfTeamsDDL()
        {
            ListItem li = new ListItem();
            li.Text = "--";
            li.Value = "0";
            ddlNumberOfTeams.Items.Add(li);
            for (int i = 4; i <= 20; i++)
            {
                ListItem li2 = new ListItem();
                li2.Text = i.ToString();
                li2.Value = i.ToString();
                ddlNumberOfTeams.Items.Add(li2);
            }
        }

        protected void btnLeagueSetup_Click(object sender, EventArgs e)
        {
            GlobalVariables.LeagueName = txtLeagueName.Text;
            GlobalVariables.NumberOfTeams = Convert.ToInt32(ddlNumberOfTeams.SelectedValue);

            Response.Redirect("~/TeamSetup.aspx");
        }
    }
}