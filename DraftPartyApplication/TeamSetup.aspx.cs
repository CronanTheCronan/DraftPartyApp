using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace DraftPartyApplication
{
    public partial class TeamSetup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(GlobalVariables.LeagueName == null || GlobalVariables.NumberOfTeams == -1)
            {
                Response.Redirect("~/LeagueSetup.aspx");
            }


            string leagueName = GlobalVariables.LeagueName;
            int cols = 2;
            int rows = GlobalVariables.NumberOfTeams;

            PopulateTeamsTable(cols, rows);
            GenerateLabelsAndTextBoxes();
        }

        private void PopulateTeamsTable(int cols, int rows)
        {
            int numOfTeams = GlobalVariables.NumberOfTeams;
            TextBox[] textBoxes = new TextBox[numOfTeams];
            Label[] labels = new Label[numOfTeams];

            for (int i = 0; i < numOfTeams; i++)
            {
                string temp = (i + 1).ToString();
                labels[i] = new Label();
                labels[i].ID = "lblTeamName" + temp;
                textBoxes[i] = new TextBox();
                textBoxes[i].ID = "txtTeamName" + temp;
            }

            StringBuilder htmlTable = new StringBuilder();
            htmlTable.AppendLine("<table id='teamsTable'>");
            htmlTable.AppendLine("<thead>");
            htmlTable.AppendLine("<tr>");

            for (int i = 1; i <= cols; i++)
            {
                if (i == 2)
                {
                    htmlTable.AppendLine("<th>Team Name</th>");
                }
                else
                {
                    htmlTable.AppendLine("<th></th>");
                }
            }

            htmlTable.AppendLine("</tr>");
            htmlTable.AppendLine("</thead>");
            htmlTable.AppendLine("<tbody>");

            for (int i = 1; i <= rows; i++)
            {
                htmlTable.AppendLine("<tr>");

                for (int j = 1; j <= cols; j++)
                {
                    if (j % 2 == 0)
                    {
                        TextBox tb = new TextBox();
                        string temp = i.ToString();
                        htmlTable.AppendLine("<td id='teamsTxtTD" + temp + "'>");
                        htmlTable.AppendLine("<input type='text' id='txtTeamName" + i + "' class='teamsInputs' />");
                        htmlTable.AppendLine("</td>");
                    }
                    else
                    {
                        Label lbl = new Label();
                        htmlTable.AppendLine("<td id='teamsLblTD" + i + "' align='right'>");
                        htmlTable.AppendLine("<label for='txtTeamName" + i + "' class='teamsLabels' id='Team" + i + "'>Team " + i + "</label>");
                        htmlTable.AppendLine("</td>");
                    }
                }

                htmlTable.AppendLine("</tr>");
            }

            htmlTable.AppendLine("</tbody>");
            htmlTable.AppendLine("</table>");

            tblTeamNames.Text = htmlTable.ToString();
        }

        private static void GenerateLabelsAndTextBoxes()
        {
            int numOfTeams = GlobalVariables.NumberOfTeams;
            TextBox[] textBoxes = new TextBox[numOfTeams];
            Label[] labels = new Label[numOfTeams];

            for (int i = 0; i < numOfTeams; i++)
            {
                string temp = (i + 1).ToString();
                labels[i] = new Label();
                labels[i].ID = "lblTeamName" + temp;
                textBoxes[i] = new TextBox();
                textBoxes[i].ID = "txtTeamName" + temp;
            }
        }

        protected void btnTeamsSetup_Click(object sender, EventArgs e)
        {
            GlobalVariables.TeamIdList = hidTeamsLabelsList.Value;
            GlobalVariables.TeamNameList = hidTeamsNamesList.Value;

            Response.Redirect("~/DraftSetup.aspx");
        }
    }
}