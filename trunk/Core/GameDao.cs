using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScoreKeeper.Core
{
    public class GameDao
    {
        private static ScoreKeeperDataContext _Db = new ScoreKeeperDataContext();
        public static System.Linq.IQueryable<Game> GetAll()
        {            
            return from p in _Db.Games select p;                   
        }

        public static Game FindByName(string gameName)
        {
            return _Db.Games.Single(p => p.Name == gameName);
        }

        public static Game FindByID(int id)
        {
            return _Db.Games.Single(p => p.ID == id);
        }

        public static void Save(Game game)
        {            
            if (game.ID == 0)
            {
                _Db.Games.InsertOnSubmit(game);
            }

            _Db.SubmitChanges();
        }
    }
}