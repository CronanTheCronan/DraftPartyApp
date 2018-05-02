using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DraftPartyApp
{
    public class Player
    {
        public int playerId { get; set; }
        public string playerLastName { get; set; }
        public string playerFirstName { get; set; }
        public int teamId { get; set; }
        public int positionId { get; set; }
    }
}