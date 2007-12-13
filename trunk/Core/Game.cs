using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ScoreKeeeper.Core
{
    public class Game
    {
        public string Name { get; set; }
        public string MatchTitle { get; set; }
        public IList<GameEvent> Events { get; set; }
    }

    public class GameEvent
    {
        public Game Game { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int ScoreInterval { get; set; }
        public int ScoreMax { get; set; }                        
    }

    public class Team : IPlayer
    {    
        public string Name { get; set; }
        public IList<Player> Players { get; set; }
        public Game Game { get; set; }
    }

    public interface IPlayer
    {
        string Name { get; set; }
    }
    public class Player
    {   
        public string Name { get; set; }                
    }

    public class MatchEvent
    {
        public Match Match {get; set;}
        public GameEvent Event { get; set; }
        public int Quantity { get; set; }
        public Player Player { get; set; }        
    }

    public class Match
    {
        public Game Game { get; set; }
        public DateTime Date { get; set; }
        public List<IPlayer> Players { get; set; }          
    }
}

