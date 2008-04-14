using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skorer.Core
{
    [System.Diagnostics.DebuggerDisplay("[{ID}] {Name}")]
    public class GameEvent : Entity<int>
    {
        private int _Points = 1;
        private int _QuantityInterval = 1;
        private int _MinimumQuantity = 1;
        private int _MaximumQuantity = 1000;

        public virtual string Name { get; set; }
        public virtual Game Game { get; set; }

        public virtual int MinimumQuantity
        {
            get
            {
                return _MinimumQuantity;
            }
            set
            {
                _MinimumQuantity = value;
            }
        }

        public virtual int MaximumQuantity
        {
            get
            {
                return _MaximumQuantity;
            }
            set
            {
                _MaximumQuantity = value;
            }
        }

        public virtual int Points
        {
            get
            {
                return _Points;
            }
            set
            {
                _Points = value;
            }
        }

        public virtual int QuantityInterval
        {
            get
            {
                return _QuantityInterval;
            }
            set
            {
                _QuantityInterval = value;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
