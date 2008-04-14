using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skorer.Core;

namespace Skorer.Services
{
    public class Scorer
    {
        #region Round

        public class Round
        {
            Scorer _Scorer;
            int _RoundNumber;
            Player _Player = null;

            public int RoundNumber
            {
                get
                {
                    return _RoundNumber;
                }
                set
                {
                    _RoundNumber = value;
                }
            }
            
            public Round(int roundNumber, Scorer scorer)
            {
                _RoundNumber = roundNumber;
                _Scorer = scorer;
            }

            public Round(int roundNumber, Scorer scorer, Player player)
            {
                _RoundNumber = roundNumber;
                _Scorer = scorer;
                _Player = player;
            }

            public Round Next
            {
                get
                {
                    if (_Scorer.Game.DistinctPlayerRounds)
                    {
                        if (_RoundNumber + 1 > _Scorer.PlayerRound(_Player).RoundNumber)
                            return null;

                        return new Round(_RoundNumber + 1, _Scorer, _Player);
                    }

                    if (_RoundNumber + 1 > _Scorer._Round)
                        return null;

                    return new Round(_RoundNumber + 1, _Scorer);
                }
            }

            public Round Previous
            {
                get
                {
                    if (_RoundNumber == 1)
                        return null;

                    if (_Scorer.Game.DistinctPlayerRounds)
                    {
                        return new Round(_RoundNumber - 1, _Scorer, _Player);
                    }

                    return new Round(_RoundNumber - 1, _Scorer);
                }
            }

            public List<MatchEvent> GetEventsFor(Player player)
            {
                List<MatchEvent> rv = _Scorer._Match.Events.FindAll(e => e.Player == player && e.Round == _RoundNumber);
                return rv;
            }

            public int GetScoreFor(Player player)
            {
                return GetEventsFor(player).Sum(e => e.Score);
            }

            public List<MatchEvent> FindPlayerEventsByEventName(Player player, string eventName)
            {
                return _Scorer._Match.Events.FindAll(e => e.Player == player && 
                    e.GameEvent.Name == eventName && e.Round == _RoundNumber);
            }

            public void DeletePlayerEventsByEventName(Player player, string eventName)
            {
                _Scorer._Match.Events.RemoveAll(e => e.Player == player && e.GameEvent.Name == eventName && e.Round == _RoundNumber);
            }
        }
        #endregion

        Game _Game;
        Match _Match;
        IGameFactory _GameFactory;
        List<GameEvent> _GameEvents = new List<GameEvent>();
        Dictionary<Player, int> playerRounds;
        
        public Round PlayerRound(Player player)
        {
            return new Round(playerRounds[player], this, player);
        }

        public Round CurrentRound
        {
            get
            {
                if (_Game.DistinctPlayerRounds)
                    throw new InvalidOperationException("A player is needed to determine the CurrentRound in this game.");
                return new Round(_Round, this);
            }
        }

        public List<Player> Players
        {
            get
            {
                return _Match.Players;
            }
        }

        public List<MatchEvent> PlayerEventPerRound(int round, Player player)
        {
            return _Match.Events.FindAll(e => e.Player == player && e.Round == round);
        }

        public int GetPlayerScore(Player player)
        {
            int rv = 0;
            foreach (MatchEvent matchEvent in _Match.Events.FindAll(e => e.Player == player))
            {
                rv += matchEvent.Score;
            }
            return rv;
        }

        public Scorer(IGameFactory gameFactory)
        {
            _GameFactory = gameFactory;
        }

        public void LoadGame(string gameName)
        {
            _Game = _GameFactory.LoadGame(gameName);
            if (_Game.DistinctPlayerRounds)
                playerRounds = new Dictionary<Player, int>();
            _Match = new Match() { Game = _Game };
        }

        public Scorer AddParticipant(Player player)
        {
            _Match.Players.Add(player);
            if (Game.DistinctPlayerRounds)
                playerRounds.Add(player, _Round);
            return this;
        }

        public Game Game
        {
            get { return _Game; }
        }

        
        protected int _Round = 1;
        protected void NewRound()
        {
            if (_Game.DistinctPlayerRounds)
                throw new InvalidOperationException("A player is needed to change rounds in this game");
            _Round++;
        }

        protected void NewRound(Player player)
        {
            if (!_Game.DistinctPlayerRounds)
                throw new InvalidOperationException("You can not get a round by player in this game");
            playerRounds[player] = playerRounds[player] + 1;            
        }

        protected virtual void ScoreEvent(MatchEvent matchEvent)
        {
            matchEvent.Score = matchEvent.Quantity * matchEvent.GameEvent.Points;
            return;
        }

        public void AddEvent(GameEvent gameEvent, Player player, int quantity)
        {
            int currentRound = _Round;
            if (Game.DistinctPlayerRounds)
                currentRound = playerRounds[player];
            MatchEvent matchEvent = new MatchEvent() { Quantity = quantity, GameEvent = gameEvent, Round = currentRound, Player = player };
            _Match.Events.Add(matchEvent);
            ScoreEvent(matchEvent);
        }

        public void AddEvent(string eventName, Player player, int quantity)
        {
            GameEvent gameEvent = _Match.Game.GetEvents().Find(g => g.Name == eventName);
            AddEvent(gameEvent, player, quantity);
        }


        
    }
}
