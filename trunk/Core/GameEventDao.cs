using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScoreKeeper.Core
{
    public class GameEventDao
    {
        public static System.Linq.IQueryable<GameEvent> GetAllByGame(Game game)
        {
            ScoreKeeperDataContext db = new ScoreKeeperDataContext();
            return from e in db.GameEvents where e.Game == game select e;
        }
    }
}
