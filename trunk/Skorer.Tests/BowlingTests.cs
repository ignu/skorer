using System;
using NUnit.Framework;
using Skorer.Core;
using Skorer.Services;
using Skorer.DataAccess;
using Moq;

namespace Skorer.Tests
{
    public class GameFactoryTestsBase
    {
        protected IGameFactory _GameFactory;
        protected Mock<IGameRepository> _GameRepositoryMock;
        protected Mock<IGameEventRepository> _GameEventRepositoryMock;
        protected Mock<IGameConfigurationPersister> _GameConfigurationPersisterMock;
        protected Mock<IMatchRepository> _MatchRepositoryMock = new Mock<IMatchRepository>();
        protected Mock<IMatchEventRepository> _MatchEventRepositoryMock = new Mock<IMatchEventRepository>();

        [SetUp]
        public virtual void TestSetup()
        {            
            _GameRepositoryMock = new Mock<IGameRepository>();
            _GameEventRepositoryMock = new Mock<IGameEventRepository>();
            _GameConfigurationPersisterMock = new Mock<IGameConfigurationPersister>();
            _GameFactory = new GameFactory(_GameConfigurationPersisterMock.Object);
            _GameConfigurationPersisterMock.Expect(g => g.SyncGame(It.IsAny<Game>()));
        }
        
    }
    [TestFixture]
    public class BowlingTests : GameFactoryTestsBase
    {
        
        [Test]
        public void CanLoadGame()
        {                        
            Game game = _GameFactory.LoadGame("Bowling");            
            Assert.AreEqual(game.Name, "Bowling");
            Assert.Greater(game.GetEvents().Count, 0);
        }

        [Test]
        public void CanHandleSpare()
        {
            Player Megatron = new Player() { FirstName = "Megatron" };
            Player Optimus = new Player() { FirstName = "Optimus" };            
            Scorer scorer = new ScorerFactory(_GameFactory, _MatchRepositoryMock.Object, _MatchEventRepositoryMock.Object).GetScorerFor("Bowling");            
            scorer.AddParticipant(Megatron).AddParticipant(Optimus);
            GameEvent throwEvent = scorer.Game.GetEvents().Find(m => m.Name == "Throw");
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
