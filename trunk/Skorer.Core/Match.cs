using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Skorer.Core
{
    [DebuggerDisplay("Match: {Game.Name} ({Date})")]
    public class Match : Entity<int>
    {
        public Game Game { get; set; }

        private List<Player> _Players = new List<Player>();
        public List<Player> Players
        {
            get
            {
                return _Players;
            }
            set
            {                
                _Players = value;
            }
        }

        private List<MatchEvent> _Events = new List<MatchEvent>();
        public List<MatchEvent> Events
        {
            get
            {
                return _Events;
            }
            set
            {
                _Events = value;
            }
        }

        private DateTime _Date = DateTime.Now;
        public DateTime Date
        {
            get { return _Date; }
            set
            {
                _Date = value;
            }
        }
        
        public void AttemptScore()
        {
            
        }

        
    }
}
