using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DraftPartyApplication
{
    public partial class Draft : System.Web.UI.Page
    {
        protected static int rows = GlobalVariables.NumberOfRounds;
        protected static int cols = GlobalVariables.NumberOfTeams;
        protected string teamIds = GlobalVariables.TeamIdList;
        protected string teamNames = GlobalVariables.TeamNameList;
        protected string leagueName = GlobalVariables.LeagueName;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblLeagueName.Text = leagueName;
            GenerateTable(rows, cols);
        }

        private void GenerateTable(int rows, int cols)
        {
            string[] teamIdsArray = teamIds.Split(',');
            string[] teamNamesArray = teamNames.Split(',');
            int roundCount = 1;

            StringBuilder htmlTable = new StringBuilder();
            htmlTable.AppendLine("<table id='draftBoard'>");
            htmlTable.AppendLine("<thead>");
            htmlTable.AppendLine("<tr>");

            for (int i = 0; i <= cols; i++)
            {
                if(i == 0)
                {
                    htmlTable.AppendLine("<th></th>");
                }
                else
                {
                    htmlTable.AppendLine("<th>");
                    htmlTable.AppendLine(teamNamesArray[i - 1]);
                    htmlTable.AppendLine("</th>");
                }
            }

            htmlTable.AppendLine("</tr>");
            htmlTable.AppendLine("</thead>");
            htmlTable.AppendLine("<tbody>");

            for (int i = 1; i <= rows; i++)
            {
                htmlTable.AppendLine("<tr>");

                for (int j = 0; j <= cols; j++)
                {
                    if(j == 0)
                    {
                        htmlTable.AppendLine("<td>Round " + roundCount + "</td>");
                        roundCount++;
                    }
                    else
                    {
                        htmlTable.AppendLine("<td id='Round" + i + "Pick" + (j) + "' class='draftCell'>");
                        htmlTable.AppendLine("</td>");
                    }
                }
                htmlTable.AppendLine("</tr>");
            }

            htmlTable.AppendLine("</tbody>");
            htmlTable.AppendLine("</table>");

            tblDraftBoard.Text = htmlTable.ToString();
        }

    }
}