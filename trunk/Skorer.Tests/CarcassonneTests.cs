using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Skorer.Core;
using Skorer.Services;

namespace Skorer.Tests
{
    [TestFixture]
    public class Tests
    {
        private Game _GetGame()
        {
            return new GameFactory().LoadGame("Carcassonne");
        }

        [Test]
        public void CanLoadGame()
        {
            Game game = _GetGame();
            Assert.AreEqual(game.Name, "Carcassonne");
            Assert.Greater(game.Events.Count, 0);
        }

        [Test]
        public void CanScoreCity()
        {            
            Player Megatron = new Player() { Name = "Megatron"  };
            Player Optimus = new Player() { Name = "Optimus" };
            
            Scorer scorer = new  ScorerFactory(new GameFactory())
                .GetScorerFor("Carcassonne");
            scorer.AddParticipant(Megatron)
                .AddParticipant(Optimus);
            
            scorer.AddEvent(scorer.Game.Events.Find(m => m.Name == "Completed City"), Megatron, 4);
            scorer.AddEvent(scorer.Game.Events.Find(m => m.Name == "Complete City With Cathedral"), Megatron, 5);
            scorer.AddEvent(scorer.Game.Events.Find(m => m.Name == "Road"), Megatron, 9);
            scorer.AddEvent(scorer.Game.Events.Find(m => m.Name == "Farmed City w/ Pig"), Optimus, 7);

            int megaTronScore = (4 * 2) +(5 * 3) + 9;
            int optimusScore = 7 * 5;

            Assert.AreEqual(megaTronScore, scorer.GetPlayerScore(Megatron));
            Assert.AreEqual(optimusScore, scorer.GetPlayerScore(Optimus));            
        }
    }
}
