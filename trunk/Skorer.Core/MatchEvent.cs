using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Skorer.Core
{
    [DebuggerDisplay("Game: {GameEvent.Name} Player: {Player.Name} Score: {Score}")]
    public class MatchEvent : Entity<int>
    {
        public virtual GameEvent GameEvent { get; set; }
        public virtual int Quantity { get; set; }
        public virtual int Round { get; set; }
        public virtual int Score { get; set; }
        public virtual Player Player { get; set; }
        
        public int GetScore()
        {            
            return Quantity * GameEvent.Points;
        }
    }
}
