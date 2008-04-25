using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iesi.Collections;
using Iesi.Collections.Generic;

namespace Skorer.Core
{
    public abstract class GameBase: Entity<int>
    {
        public virtual string Name { get; set; }
        public virtual bool DistinctPlayerRounds { get; set; }

        protected List<GameEvent> _GameEventList;
        public virtual List<GameEvent> GetEvents()
        {
            if (_GameEventList == null)
                _GameEventList = new List<GameEvent>(Events);

            return _GameEventList;
        }

        public virtual void AddEvent(GameEvent eventToAdd)
        {
            if (_Events == null)
                _Events = new HashedSet<GameEvent>();
            _GameEventList = null;
            _Events.Add(eventToAdd);
        }

        protected ISet<GameEvent> _Events;

        protected virtual ISet<GameEvent> Events
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



    }
    public class GameData : GameBase
    {        
        public virtual void Prepare() { }
        
        public virtual void SetName(string name)
        {
            Name = name;
        }
    
    }

    [System.Diagnostics.DebuggerDisplay("[{ID}] {Name}")]
    public class Game : GameBase
    {                                                                
        public override string ToString()
        {
            return Name;
        }
    }
}