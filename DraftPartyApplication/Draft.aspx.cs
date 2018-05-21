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
        FantasyFootballDBDataContext ffddc = new FantasyFootballDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (GlobalVariables.NumberOfRounds <= 0)
            //{
            //    Response.Redirect("~/LeagueSetup.aspx");
            //}
            
            SetupPage();
            GenerateTable(rows, cols);
            
        }

        private void SetupPage()
        {
            lblLeagueName.Text = leagueName;
            PopulateDDLs();
        }

        private void PopulateDDLs()
        {

            ddlPositionFilter.DataSource = ffddc.Positions;
            ddlPositionFilter.DataTextField = "position_name";
            ddlPositionFilter.DataValueField = "position_id";
            ddlPositionFilter.DataBind();

            ddlTeamsFilter.DataSource = ffddc.Teams;
            ddlTeamsFilter.DataTextField = "team_name";
            ddlTeamsFilter.DataValueField = "team_id";
            ddlTeamsFilter.DataBind();
        }

        private void GenerateTable(int rows, int cols)
        {
            string[] teamIdsArray = teamIds.Split(',');
            string[] teamNamesArray = teamNames.Split(',');

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

                if (i % 2 == 1)
                {
                    for (int j = 0; j <= cols; j++)
                    {
                        if (j == 0)
                        {
                            htmlTable.AppendLine("<td>Round " + i + "</td>");
                        }
                        else
                        {
                            htmlTable.AppendLine("<td id='Round" + i + "Pick" + (j) + "' class='draftCell'>");
                            htmlTable.AppendLine("</td>");
                        }
                    }
                    
                }
                else
                {
                    for (int j = cols + 1; j >= 1; j--)
                    {
                        if (j == cols + 1)
                        {
                            htmlTable.AppendLine("<td>Round " + i + "</td>");
                        }
                        else
                        {
                            
                            htmlTable.AppendLine("<td id='Round" + i + "Pick" + (j) + "' class='draftCell'>");
                            htmlTable.AppendLine("</td>");
                        }
                    }
                }
                htmlTable.AppendLine("</tr>");
            }

            htmlTable.AppendLine("</tbody>");
            htmlTable.AppendLine("</table>");

            tblDraftBoard.Text = htmlTable.ToString();
        }


        //protected void playerFilter()
        //{
        //    gvTest.DataSource = from player in ffddc.Players
        //                        where player.position_id == ddlPositionFilter.SelectedIndex
        //                        && player.team_id == ddlTeamsFilter.SelectedIndex
        //                        select player;

        //    gvTest.DataBind();
        //}
    }
}