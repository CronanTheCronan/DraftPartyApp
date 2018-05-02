using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Web.UI.HtmlControls;
using DraftPartyApp.App_Data;

namespace DraftPartyApp
{
    public partial class DraftRoom : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            FootbalLinqDataDataContext linqCon = new FootbalLinqDataDataContext();

            

            LoadTeamsDDL(linqCon);
            LoadPositionDDL(linqCon);

            string CS = "data source=.; database = FantasyFootball; integrated security=SSPI";

            using (SqlConnection con = new SqlConnection(CS))
            {

                SqlDataAdapter da = new SqlDataAdapter("sp_GetPlayersByFilter", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                da.Fill(ds);
                dt = ds.Tables["Players"];

                int i = 1;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string divId = "div" + i;
                    string script = "<script type='text/javascript'>alert('" + row["last_name"] + "');</script>";
                    Response.Write(script);

                    CreateDiv(divId);
                    i++;
                }
            }
        }

        private void CreateDiv(string divId)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", divId);
            div.Attributes.Add("class", "test");
            div.Attributes.CssStyle.Add("width", "150px");
            div.Attributes.CssStyle.Add("background-color", "red");
            divPlayerTable.Controls.Add(div);
        }

        private void LoadTeamsDDL(FootbalLinqDataDataContext linqCon)
        {
            ddlTeams.DataSource = linqCon.Teams;
            ddlTeams.DataTextField = "team_name";
            ddlTeams.DataValueField = "team_id";

            ddlTeams.DataBind();

            ddlTeams.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlTeams.SelectedIndex = 0;
        }

        private void LoadPositionDDL(FootbalLinqDataDataContext linqCon)
        {
            ddlPositions.DataSource = linqCon.Positions;

            ddlPositions.DataTextField = "position_name";
            ddlPositions.DataValueField = "position_id";

            ddlPositions.DataBind();

            ddlPositions.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlPositions.SelectedIndex = 0;
        }

        protected int setCurrentRound()
        {
            Draft draft = new Draft();
            int currentRound = draft.currentRound = 0;

            return draft.currentRound;
        }

        protected void ddlPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            int playerID = ddlPositions.SelectedIndex;

        }
    }
}