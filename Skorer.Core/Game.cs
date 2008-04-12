using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skorer.Core
{
    public class Game : Entity<int>
    {        
        public virtual void Prepare() {}

        public virtual string Name { get; set; }
        public virtual bool DistinctPlayerRounds { get; set; }
        private List<GameEvent> _Events = new List<GameEvent>();
        public virtual List<GameEvent> Events
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

        public virtual void SetName(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}