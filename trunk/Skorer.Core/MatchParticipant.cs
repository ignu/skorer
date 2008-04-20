using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skorer.Core
{
    public class MatchParticipant
    {
        public Player Player { get; set;}
        public Match Match { get; set; }
        public int Score { get; set; }                               
    }
}
