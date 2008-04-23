using System;
using NUnit.Framework;
using Skorer.Core;
using Skorer.Services;
using Moq;
using Skorer.DataAccess;

namespace Skorer.Tests
{
    [TestFixture]
    public class ScorerTests
    {
        private const string GAME_NAME = "Carcassonne";

        Scorer _Scorer;

        [SetUp]
        public void SetUp()
        {            
            Mock<Skorer.Services.IGameDataFactory> gameFactory = new Mock<Skorer.Services.IGameDataFactory>();
            Mock<Game> carc = new Mock<Game>();
            Mock<IMatchRepository> matchRepository = new Mock<IMatchRepository>();
            Mock<IMatchEventRepository> matchEventRepository = new Mock<IMatchEventRepository>();

            gameFactory.Expect(corer => corer.LoadGame("Carcassonne"))
                .Returns(carc.Object);

            _Scorer = new Scorer(gameFactory.Object, matchRepository.Object, matchEventRepository.Object);
                        
            _Scorer.LoadGame("Carcassonne");
        }

        [Test]
        public void Can_Add_Participant()
        {
            Player player = new Player() { FirstName = "Len" };
            _Scorer.AddParticipant(player);
            Assert.IsNotEmpty(_Scorer.Players);
        }

        [Test]
        public void Scorer_Can_Add_Event()
        {
            
            //_Scorer.AddEvent(new MatchEvent());
        }

        [Test]
        public void Scorer_Can_Initialize()
        {
            
        }
    }
}
