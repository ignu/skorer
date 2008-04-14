using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skorer.Core
{

    [System.Diagnostics.DebuggerDisplay("[{ID}] {Name}")]
    public class Team : Entity<int>
    {
        public string Name { get; set; }
        public Game Game { get; set; }
        public List<Player> Players { get; set; }
    }
}
