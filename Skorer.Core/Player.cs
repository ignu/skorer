using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skorer.Core
{

    [System.Diagnostics.DebuggerDisplay("[{ID}] {Name}")]
    public class Player : Entity<int>
    {
        public string Name { get; set; }
    }
}