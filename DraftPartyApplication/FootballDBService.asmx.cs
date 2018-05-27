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
        DataTable dt = new DataTable();

        private void PopulateDataTable()
        {
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

        [WebMethod(EnableSession = true)]
        public void GetAllPlayers()
        {
            List<FFPlayers> listPlayers = new List<FFPlayers>();

            PopulateDataTable();
            var results = from row in dt.AsEnumerable()
                          select new
                          {
                              PlayerID = row.Field<int>("PlayerID"),
                              FirstName = row.Field<string>("FirstName"),
                              LastName = row.Field<string>("LastName"),
                              PositionID = row.Field<int>("PositionID"),
                              PositionName = row.Field<string>("PositionName"),
                              TeamID = row.Field<int>("TeamID"),
                              TeamName = row.Field<string>("TeamName")
                          };
            foreach (var result in results)
            {
                FFPlayers player = new FFPlayers();
                player.PlayerID = result.PlayerID;
                player.PlayerFirstName = result.FirstName;
                player.PlayerLastName = result.LastName;
                player.PositionID = result.PositionID;
                player.PositionName = result.PositionName;
                player.TeamID = result.TeamID;
                player.TeamName = result.TeamName;
                listPlayers.Add(player);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listPlayers));
        }

        [WebMethod(EnableSession = true)]
        public void GetPlayersFromFilter(int posID, int teamID)
        {
            DataTable dt = (DataTable)Session["tempTable"];
            var results = from row in dt.AsEnumerable()
                          where row.Field<int>("PositionID") == posID
                          && row.Field<int>("TeamID") == teamID
                          select new
                          {
                              PositionName = row.Field<string>("PositionName"),
                              FirstName = row.Field<string>("FirstName"),
                              LastName = row.Field<string>("LastName"),
                              TeamName = row.Field<string>("TeamName")
                          };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(results));
        }

        [WebMethod(EnableSession = true)]
        public void RemovePlayerFromTable(int playerID)
        {
            DataTable dt = (DataTable)Session["tempTable"];
            dt.AsEnumerable().Where(row => row.Field<int>("PlayerID") == playerID).ToList().ForEach(row => row.Delete());
            dt.AcceptChanges();
                          
        }
    }
}
