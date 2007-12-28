using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScoreKeeper.Core
{
    public class PlayerScore
    {
        public Player Player { get; set; }
        public int Score { get; set; }
        /// <summary>
        /// Initializes a new instance of the PlayerScore class.
        /// </summary>
        public PlayerScore(Player player, int score)
        {
            Player = player;
            Score = score;
        }
    }
}
