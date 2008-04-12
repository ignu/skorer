using System;
using NUnit.Framework;
using Skorer.DataAccess;
using Skorer.Core;
using Skorer.IOC;

namespace Skorer.Tests.Repository
{
    [TestFixture]
    public class PlayerTests : RepositoryTestBase<IRepository<Player, int>>
    {
        [Test]
        public void CanSaveAndRetrieve()
        {
            Player p = new Player();
            _Repository.Save(p);
            Assert.Greater(p.ID, 0);
        }
    }
}
