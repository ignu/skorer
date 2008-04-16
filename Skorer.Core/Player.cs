using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skorer.Core
{

    [System.Diagnostics.DebuggerDisplay("[{ID}] {FirstName} {LastName}")]
    public class Player : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }

    
}
