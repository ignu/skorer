using System;
using NUnit.Framework;
using Skorer.DataAccess;
using Skorer.Core;
using Skorer.IOC;

namespace Skorer.Tests.Repository
{
    [TestFixture]
    public class MatchEventTests : RepositoryTestBase<IMatchEventRepository>
    {
        [Test]
        public void CanSaveAndRetrieve()
        {
            Game game = Container.Resolve<IRepository<Game, int>>().GetFirst();
            Player player = Container.Resolve<IRepository<Player, int>>().GetFirst();
            MatchEvent e = new MatchEvent { GameEvent = game.GetEvents()[0], Player = player, Quantity = 1, Score = 0, Round = 1 };
            _Repository.Save(e);
            Assert.Greater(e.ID, 0);
        }
    }
}
