using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScoreKeeper.Core
{
    public static class MatchDao
    {
        static ScoreKeeperDataContext _Db = new ScoreKeeperDataContext();

        public static Match CreateFromGame(Game game)
        {
            Match match = new Match() { GameID = game.ID, MatchDate = DateTime.Now };
            _Db.SubmitChanges();
            return match;
        }

        public static void AddPlayers(List<Player> players, Match match)
        {
            foreach (Player player in players)
            {
                MatchParticipant participant = new MatchParticipant() { MatchID = match.ID, PlayerID = player.ID };
                _Db.MatchParticipants.InsertOnSubmit(participant);
                match.MatchParticipants.Add(participant);
            }

            _Db.SubmitChanges();
        }
    }
}
