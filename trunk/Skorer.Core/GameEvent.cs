using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skorer.Core
{
    public class GameEvent
    {
        private int _Points = 1;
        private int _QuantityInterval = 1;
        private int _MinimumQuantity = 1;
        private int _MaximumQuantity = 1000;

        public string Name { get; set; }

        public int MinimumQuantity
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

        public int MaximumQuantity
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

        public int Points
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

        public int QuantityInterval
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
