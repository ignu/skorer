using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skorer.Core
{
    public abstract class Game
    {        
        public abstract void Prepare();

        public string Name { get; set; }
        public bool DistinctPlayerRounds { get; set; }
        private List<GameEvent> _Events = new List<GameEvent>();
        public List<GameEvent> Events
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

        public void SetName(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}