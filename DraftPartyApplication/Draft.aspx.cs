using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DraftPartyApplication
{
    public partial class Draft : System.Web.UI.Page
    {
        protected static int rows = 16;
        protected static int cols = 6;
        protected string teamIds = "team1,team2,team3,team4,team5,team6";
        protected string teamNames = "team1,team2,team3,team4,team5,team6";
        protected string leagueName = "testleague";
        protected bool isdrafting = false;
        protected DataTable tempPlayerTable = new DataTable();

        //protected static int rows = GlobalVariables.NumberOfRounds;
        //protected static int cols = GlobalVariables.NumberOfTeams;
        //protected string teamIds = GlobalVariables.TeamIdList;
        //protected string teamNames = GlobalVariables.TeamNameList;
        //protected string leagueName = GlobalVariables.LeagueName;
        //protected bool isDrafting = GlobalVariables.IsDrafting;

        FootballDBLinqDataContext ffddc = new FootballDBLinqDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (GlobalVariables.NumberOfRounds <= 0)
            //{
            //    Response.Redirect("~/LeagueSetup.aspx");
            //}

            if (!IsPostBack)
            {
                PopulateDataTable();
                SetupPage();
                GenerateTable(rows, cols);
            }
        }

        private void PopulateDataTable()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FootballDBConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllPlayers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
            Session["tempTable"] = dt;
        }

        private void SetupPage()
        {
            lblLeagueName.Text = leagueName;
            PopulateDDLs();
        }

        private void PopulateDDLs()
        {

            ddlPositionFilter.DataSource = ffddc.Positions;
            ddlPositionFilter.DataTextField = "name";
            ddlPositionFilter.DataValueField = "posId";
            ddlPositionFilter.DataBind();
            ddlPositionFilter.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlPositionFilter.SelectedIndex = 0;

            ddlTeamsFilter.DataSource = ffddc.Teams;
            ddlTeamsFilter.DataTextField = "teamCode";
            ddlTeamsFilter.DataValueField = "teamId";
            ddlTeamsFilter.DataBind();
            ddlTeamsFilter.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlTeamsFilter.SelectedIndex = 0;
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
    }
}