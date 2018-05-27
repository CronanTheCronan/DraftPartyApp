using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DraftPartyApplication
{
    public class FFPlayers
    {
        public int PlayerID { get; set; }
        public string PlayerLastName { get; set; }
        public string PlayerFirstName { get; set; }
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public int TeamID { get; set; }
        public string TeamName { get; set; }
    }
}