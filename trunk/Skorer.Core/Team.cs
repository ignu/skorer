using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skorer.Core
{
    public class Team
    {
        public string Name { get; set; }
        public Game Game { get; set; }
        public List<Player> Players { get; set; }
    }
}
