using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScoreKeeper.Core
{
    public static class MatchEventDao
    {

        static ScoreKeeperDataContext _Db = new ScoreKeeperDataContext();

        public static void Save(MatchEvent matchEvent)
        {
            _Db.MatchEvents.InsertOnSubmit(matchEvent);
            _Db.SubmitChanges();
        }

        public static List<PlayerScore> GetScores(int matchID)
        {
            List<PlayerScore> rv = new List<PlayerScore>();
            var results = from p in _Db.MatchEvents
                          where p.MatchID == matchID
                          group p by p.Player into s
                          select new { Player = s.Key, Score = s.Sum(a => a.Score) };

            foreach (var result in results.OrderByDescending(p => p.Score))
            {
                rv.Add(new PlayerScore(result.Player, result.Score));
            }

            return rv;
        }
    }
}
