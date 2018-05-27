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
        protected string teamIds = "Team1,Team2,Team3,Team4,Team5,Team6";
        protected string teamNames = "Team1,Team2,Team3,Team4,Team5,Team6";
        protected string leagueName = "TestLeague";
        protected bool isDrafting = false;
        protected DataTable tempPlayerTable = new DataTable();

        //protected static int rows = GlobalVariables.NumberOfRounds;
        //protected static int cols = GlobalVariables.NumberOfTeams;
        //protected string teamIds = GlobalVariables.TeamIdList;
        //protected string teamNames = GlobalVariables.TeamNameList;
        //protected string leagueName = GlobalVariables.LeagueName;
        //protected bool isDrafting = GlobalVariables.IsDrafting;

        FantasyFootballDBDataContext ffddc = new FantasyFootballDBDataContext();

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
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FantasyFootballConnectionString"].ConnectionString))
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
            ddlPositionFilter.DataTextField = "position_name";
            ddlPositionFilter.DataValueField = "position_id";
            ddlPositionFilter.DataBind();
            ddlPositionFilter.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlPositionFilter.SelectedIndex = 0;

            ddlTeamsFilter.DataSource = ffddc.Teams;
            ddlTeamsFilter.DataTextField = "team_name";
            ddlTeamsFilter.DataValueField = "team_id";
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

        //protected void btnStartDraft_Click(object sender, EventArgs e)
        //{
        //    isDrafting = true;

        //    Session["tempTable"] = tempPlayerTable;

        //    var results = from row in tempPlayerTable.AsEnumerable()
        //                  where row.Field<int>("PositionID") == 1
        //                    && row.Field<int>("TeamID") == 1
        //                  select new
        //                  {
        //                      PositionName = row.Field<string>("PositionName"),
        //                      FirstName = row.Field<string>("FirstName"),
        //                      LastName = row.Field<string>("LastName"),
        //                      TeamName = row.Field<string>("TeamName")
        //                  };

        //    GridView1.DataSource = results;
        //    GridView1.DataBind();


        //}

        //protected void btnFilterPlayers_Click(object sender, EventArgs e)
        //{
        //    GridView1.DataSource = null;

        //    var tempPlayerTable2 = (DataTable)Session["tempTable"];

        //    var results = from row in tempPlayerTable2.AsEnumerable()
        //                  where row.Field<int>("PositionID") == (ddlPositionFilter.SelectedIndex + 1)
        //                        && row.Field<int>("TeamID") == (ddlTeamsFilter.SelectedIndex + 1)
        //                  select new
        //                  {
        //                      PositionName = row.Field<string>("PositionName"),
        //                      FirstName = row.Field<string>("FirstName"),
        //                      LastName = row.Field<string>("LastName"),
        //                      TeamName = row.Field<string>("TeamName")
        //                  };

        //    GridView1.DataSource = results;
        //    GridView1.DataBind();
        //}
    }
}