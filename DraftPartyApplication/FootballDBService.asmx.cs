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

        [WebMethod(EnableSession = true)]
        public void GetAllPlayers()
        {
            List<FFPlayers> listPlayers = new List<FFPlayers>();

            PopulateDataTable();
            var results = from row in dt.AsEnumerable()
                          select new
                          {
                              PlayerId = row.Field<int>("PlayerId"),
                              LastName = row.Field<string>("LastName"),
                              FirstName = row.Field<string>("FirstName"),
                              FullName = row.Field<string>("FullName"),
                              JerseyNumber = row.Field<int>("JerseyNumber"),
                              PositionId = row.Field<int>("PositionId"),
                              Position = row.Field<string>("Position"),
                              TeamId = row.Field<int>("TeamId"),
                              Team = row.Field<string>("Team"),
                              ByeWeek = row.Field<int>("ByeWeek"),
                              PositionRank = row.Field<int>("PositionRank"),
                              OverallRank = row.Field<int>("OverallRank")
                          };

            foreach (var result in results)
            {
                FFPlayers player = new FFPlayers();
                player.PlayerId = result.PlayerId;
                player.LastName = result.LastName;
                player.FirstName = result.FirstName;
                player.FullName = result.FullName;
                player.JerseyNumber = result.JerseyNumber;
                player.PositionId = result.PositionId;
                player.Position = result.Position;
                player.TeamId = result.TeamId;
                player.Team = result.Team;
                player.ByeWeek = result.ByeWeek;
                player.PositionRank = result.PositionRank;
                player.OverallRank = result.OverallRank;
                listPlayers.Add(player);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listPlayers));
        }

        [WebMethod(EnableSession = true)]
        public void GetTopAvailable(int posID, int teamID)
        {
            List<FFPlayers> listPlayers = new List<FFPlayers>();

            DataTable dt = (DataTable)Session["tempTable"];
            var results = from row in dt.AsEnumerable()
                          where row.Field<int>("PositionId") == posID
                          && row.Field<int>("TeamId") == teamID
                          select new
                          {
                              PlayerId = row.Field<int>("PlayerId"),
                              PositionId = row.Field<int>("PositionId"),
                              Position = row.Field<string>("Position"),
                              FirstName = row.Field<string>("FirstName"),
                              LastName = row.Field<string>("LastName"),
                              TeamId = row.Field<int>("TeamId"),
                              TeamName = row.Field<string>("TeamName")
                          };

            foreach (var result in results)
            {
                FFPlayers player = new FFPlayers();
                player.PlayerId = result.PlayerId;
                player.PositionId = result.PositionId;
                player.Position = result.Position;
                player.FirstName = result.FirstName;
                player.LastName = result.LastName;
                player.TeamId = result.TeamId;
                player.Team = result.TeamName;
                listPlayers.Add(player);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listPlayers));
        }

        [WebMethod(EnableSession = true)]
        public void GetPlayersFromFilter(int posID, int teamID)
        {
            List<FFPlayers> listPlayers = new List<FFPlayers>();

            DataTable dt = (DataTable)Session["tempTable"];
            var results = from row in dt.AsEnumerable()
                          where row.Field<int>("PositionId") == posID
                          && row.Field<int>("TeamId") == teamID
                          select new
                          {
                              PlayerId = row.Field<int>("PlayerId"),
                              PositionId = row.Field<int>("PositionId"),
                              Position = row.Field<string>("Position"),
                              FirstName = row.Field<string>("FirstName"),
                              LastName = row.Field<string>("LastName"),
                              TeamId = row.Field<int>("TeamId"),
                              Team = row.Field<string>("Team")
                          };

            foreach(var result in results)
            {
                FFPlayers player = new FFPlayers();
                player.PlayerId = result.PlayerId;
                player.PositionId = result.PositionId;
                player.Position = result.Position;
                player.FirstName = result.FirstName;
                player.LastName = result.LastName;
                player.TeamId = result.TeamId;
                player.Team = result.Team;
                listPlayers.Add(player);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listPlayers));
        }

        [WebMethod(EnableSession = true)]
        public void GetPlayerByID(int playerID)
        {
            List<FFPlayers> listPlayers = new List<FFPlayers>();

            DataTable dt = (DataTable)Session["tempTable"];
            var results = from row in dt.AsEnumerable()
                          where row.Field<int>("PlayerId") == playerID
                          select new
                          {
                              PlayerId = row.Field<int>("PlayerId"),
                              PositionId = row.Field<int>("PositionId"),
                              Position = row.Field<string>("Position"),
                              FirstName = row.Field<string>("FirstName"),
                              LastName = row.Field<string>("LastName"),
                              TeamId = row.Field<int>("TeamId"),
                              Team = row.Field<string>("Team")
                          };

            foreach (var result in results)
            {
                FFPlayers player = new FFPlayers();
                player.PlayerId = result.PlayerId;
                player.PositionId = result.PositionId;
                player.Position = result.Position;
                player.FirstName = result.FirstName;
                player.LastName = result.LastName;
                player.TeamId = result.TeamId;
                player.Team = result.Team;
                listPlayers.Add(player);
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listPlayers));
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
