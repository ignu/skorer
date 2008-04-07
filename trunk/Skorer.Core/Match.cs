using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skorer.Core
{
    public class Match
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

        public void AttemptScore()
        {
            
        }
    }
}
