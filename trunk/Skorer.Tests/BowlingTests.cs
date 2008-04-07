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
    public class BowlingTests
    {
        [Test]
        public void CanLoadGame()
        {
            Game game = new GameFactory().LoadGame("Bowling");
            Assert.AreEqual(game.Name, "Bowling");
            Assert.Greater(game.Events.Count, 0);
        }

        [Test]
        public void CanHandleSpare()
        {
            Player Megatron = new Player() { Name = "Megatron" };
            Player Optimus = new Player() { Name = "Optimus" };

            Scorer scorer = new ScorerFactory(new GameFactory()).GetScorerFor("Bowling");            
            scorer.AddParticipant(Megatron).AddParticipant(Optimus);
            GameEvent throwEvent = scorer.Game.Events.Find(m => m.Name == "Throw");
            scorer.AddEvent(throwEvent, Megatron, 4);
            scorer.AddEvent(throwEvent, Megatron, 6);
            scorer.AddEvent(throwEvent, Optimus, 10);            
            scorer.AddEvent(throwEvent, Megatron, 2);
            scorer.AddEvent(throwEvent, Megatron, 1);
            scorer.AddEvent(throwEvent, Optimus, 10);
            scorer.AddEvent(throwEvent, Megatron, 0);
            scorer.AddEvent(throwEvent, Megatron, 1);
            scorer.AddEvent(throwEvent, Optimus, 0);

            int megaTronScore = 12 + 3 + 1;
            
            Assert.AreEqual(megaTronScore, scorer.GetPlayerScore(Megatron));
            Assert.AreEqual(30, scorer.GetPlayerScore(Optimus));
        }
    }
}
