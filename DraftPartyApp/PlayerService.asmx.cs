using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Services;
using System.Data;
using System.Web.Script.Serialization;
using System.Data.SqlClient;

namespace DraftPartyApp
{
    /// <summary>
    /// Summary description for PlayerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class PlayerService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetPlayers()
        {
            List<Player> listPlayers = new List<Player>();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Players where position_id = 1 and team_id = 2", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataView dataView = new DataView(ds.Tables[0]);
                
                foreach(DataRow playerDataRow in ds.Tables[0].Rows)
                {
                    Player player = new Player();
                    player.playerId = Convert.ToInt32(playerDataRow["player_id"]);
                    player.playerLastName = playerDataRow["last_name"].ToString();
                    player.playerFirstName = playerDataRow["first_name"].ToString();
                    player.positionId = Convert.ToInt32(playerDataRow["position_id"]);
                    player.teamId = Convert.ToInt32(playerDataRow["team_id"]);

                    listPlayers.Add(player);
                }

            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listPlayers));
        }
    }
}
