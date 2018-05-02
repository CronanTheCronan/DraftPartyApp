using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DraftPartyApp
{
    public class Team
    {
        public int teamId { get; set; }
        public string teamAbbr { get; set; }
        public string teamName { get; set; }
        public string teamCity { get; set; }
        public int teamDivId { get; set; }
    }
}