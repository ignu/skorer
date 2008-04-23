using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Skorer.Core;
using Skorer.Services;
using Moq;

namespace Skorer.Tests
{
    [TestFixture]
    public class CarcassonneTests : GameFactoryTestsBase
    {
        private Game _GetGame()
        {
            return _GameFactory.LoadGame("Carcassonne");
        }

        [Test]
        public void CanLoadGame()
        {
            Game game = _GetGame();
            Assert.AreEqual(game.Name, "Carcassonne");
            Assert.Greater(game.GetEvents().Count, 0);
        }

        [Test]
        public void Will_Sync_With_Database()
        {
            Game game = _GetGame();
            _GameEventRepositoryMock
                .Expect(g => g.SaveOrUpdate(It.IsAny<GameEvent>()))
                .Returns(game.GetEvents()[0]);
        }

        [Test]
        public void CanScoreCity()
        {            
            Player Megatron = new Player() { FirstName = "Megatron"  };
            Player Optimus = new Player() { FirstName = "Optimus" };
            
            Scorer scorer = new  ScorerFactory(_GameFactory, _MatchRepositoryMock.Object, _MatchEventRepositoryMock.Object).GetScorerFor("Carcassonne");
            
            scorer.AddParticipant(Megatron).AddParticipant(Optimus);
            
            scorer.AddEvent("Completed City", Megatron, 4);
            scorer.AddEvent("Complete City With Cathedral", Megatron, 5);
            scorer.AddEvent("Road", Megatron, 9);
            scorer.AddEvent("Farmed City w/ Pig", Optimus, 7);

            int megaTronScore = (4 * 2) +(5 * 3) + 9;
            int optimusScore = 7 * 5;

            Assert.AreEqual(megaTronScore, scorer.GetPlayerScore(Megatron));
            Assert.AreEqual(optimusScore, scorer.GetPlayerScore(Optimus));            
        }
    }
}
