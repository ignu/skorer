using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScoreKeeper.Core
{
    public class PlayerDao
    {
        public static System.Linq.IQueryable<Player> GetAll()
        {
            ScoreKeeperDataContext db = new ScoreKeeperDataContext();
            return from p in db.Players select p;
        }

        public static Player FindByID(int id)
        {
            ScoreKeeperDataContext db = new ScoreKeeperDataContext();
            return db.Players.Single(p => p.ID == id);
        }
    }
}