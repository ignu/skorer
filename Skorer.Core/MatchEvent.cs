using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Skorer.Core
{
    [DebuggerDisplay("Game: {GameEvent.Name} Player: {Player.Name} Score: {Score}")]
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
