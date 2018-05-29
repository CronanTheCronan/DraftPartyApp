using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DraftPartyApplication
{
    public class FFPlayers
    {
        public int PlayerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public int JerseyNumber { get; set; }
        public int PositionId { get; set; }
        public string Position { get; set; }
        public int TeamId { get; set; }
        public string Team { get; set; }
        public int ByeWeek { get; set; }
        public int PositionRank { get; set; }
        public int OverallRank { get; set; }
    }
}