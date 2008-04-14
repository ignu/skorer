using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iesi.Collections;
using Iesi.Collections.Generic;

namespace Skorer.Core
{
    [System.Diagnostics.DebuggerDisplay("[{ID}] {Name}")]
    public class Game : Entity<int>
    {        
        public virtual void Prepare() {}

        public virtual string Name { get; set; }
        public virtual bool DistinctPlayerRounds { get; set; }
        private ISet<GameEvent> _Events = new HashedSet<GameEvent>();
        private List<GameEvent> _GameEventList;

        public virtual List<GameEvent> GetEvents()
        {
            if (_GameEventList == null)
                _GameEventList = new List<GameEvent>(_Events);

            return _GameEventList;
        }

        public virtual void AddEvent(GameEvent eventToAdd)
        {
            _Events.Add(eventToAdd);            
        }

        public virtual ISet<GameEvent> Events
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