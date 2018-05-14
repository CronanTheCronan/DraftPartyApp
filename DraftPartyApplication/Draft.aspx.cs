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
        Dictionary<string, string> teamNamesDict = new Dictionary<string, string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateTeamsDictionary();
            GenerateTable(rows, cols);
        }

        private void GenerateTable(int rows, int cols)
        {
            string[] teamIdsArray = teamIds.Split(',');
            string[] teamNamesArray = teamNames.Split(',');

            StringBuilder htmlTable = new StringBuilder();
            htmlTable.AppendLine("<table id='draftBoard'>");
            htmlTable.AppendLine("<thead>");
            htmlTable.AppendLine("<tr>");

            for (int i = 1; i <= cols; i++)
            {
                htmlTable.AppendLine("<th>");
                htmlTable.AppendLine(teamNamesArray[i - 1]);
                htmlTable.AppendLine("</th>");
            }

            htmlTable.AppendLine("</tr>");
            htmlTable.AppendLine("</thead>");
            htmlTable.AppendLine("<tbody>");

            for (int i = 1; i <= rows; i++)
            {
                htmlTable.AppendLine("<tr>");

                for (int j = 1; j <= cols; j++)
                {
                    htmlTable.AppendLine("<td>");
                    htmlTable.AppendLine("</td>");
                }

                htmlTable.AppendLine("</tr>");
            }

            htmlTable.AppendLine("</tbody>");
            htmlTable.AppendLine("</table>");

            tblDraftBoard.Text = htmlTable.ToString();
        }

        private void PopulateTeamsDictionary()
        {
            string[] teamIdsArray = teamIds.Split(',');
            string[] teamNamesArray = teamNames.Split(',');

            for (int i = 0; i < teamIdsArray.Length; i++)
            {
                teamNamesDict.Add(teamIdsArray[i], teamNamesArray[i]);
            }
        }
    }
}