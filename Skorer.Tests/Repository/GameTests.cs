using System;
using NUnit.Framework;
using Skorer.DataAccess;
using Skorer.Core;
using Skorer.IOC;

namespace Skorer.Tests.Repository
{
    [TestFixture]
    public class GameTests : RepositoryTestBase<IRepository<Game, int>>
    {
        [Test]
        public void CanSaveAndRetrieve()
        {
            Game game = new Game { Name = "BaseBall" };
            _Repository.Save(game);
            Assert.Greater(game.ID, 0);            
        }

        [Test]
        public void GameHasEvents()
        {
            Game game = _Repository.GetFirst();
            Assert.Greater(game.Events.Count, 0);
        }
    }

}