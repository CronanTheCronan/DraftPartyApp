using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace DraftPartyApplication
{
    /// <summary>
    /// Summary description for FootballDBService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class FootballDBService : System.Web.Services.WebService
    {

        [WebMethod]
        public  void GetPlayersFromFilter(int posID, int teamID)
        {
            List<FFPlayers> listPlayers = new List<FFPlayers>();

            string cs = ConfigurationManager.ConnectionStrings["FantasyFootballConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_GetPlayersByFilter", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@positionID", posID));
                cmd.Parameters.Add(new SqlParameter("@teamID", teamID));
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while(rdr.Read())
                {
                    FFPlayers player = new FFPlayers();
                    player.PlayerName = rdr["PlayerName"].ToString();
                    player.PositionID = Convert.ToInt32(rdr["PositionID"]);
                    player.PositionName = rdr["PositionName"].ToString();
                    player.TeamID = Convert.ToInt32(rdr["TeamID"]);
                    player.TeamName = rdr["TeamName"].ToString();
                    listPlayers.Add(player);
                }

            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listPlayers));
        }
    }
}
