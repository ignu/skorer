using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScoreKeeper.Core
{
    public partial class Game
    {
        public override string ToString()
        {
            return String.Format("{0} [{1}]", this.Name, this.ID);
        }
    }
}
