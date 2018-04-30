using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DraftPartyApp.App_Data;

namespace DraftPartyApp
{
    public partial class DraftRoom : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            FootbalLinqDataDataContext linqCon = new FootbalLinqDataDataContext();

            LoadPositionDDL(linqCon);
            LoadTeamsDDL(linqCon);

            gvPlayers.DataSource = from player in linqCon.Players
                                   where player.position_id == 1 && player.team_id == 2
                                   select player;
            gvPlayers.DataBind();

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
            draft.currentRound = 0;

            return draft.currentRound;
        }

        protected void ddlPositions_SelectedIndexChanged(object sender, EventArgs e)
        {
            int playerID = ddlPositions.SelectedIndex;

            

        }
    }
}