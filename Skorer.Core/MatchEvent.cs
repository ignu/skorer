using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skorer.Core
{
    public class MatchEvent
    {
        public GameEvent GameEvent { get; set; }
        public int Quantity { get; set; }
        public int Round { get; set; }
        public int Score { get; set; }
        public Player Player { get; set; }
        
        public int GetScore()
        {
            return Quantity * GameEvent.Points;
        }
    }
}
