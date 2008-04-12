using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skorer.Core
{
    [System.Diagnostics.DebuggerDisplay("{ID} {Type}")]
    public class Entity<T>
    {
        public virtual T ID { get; set; }
    }
}
