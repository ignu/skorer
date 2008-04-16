using System;
using NUnit.Framework;
using Skorer.DataAccess;
using Skorer.Core;
using Skorer.IOC;

namespace Skorer.Tests.Repository
{
    [TestFixture]
    public class PlayerRepositoryTests : RepositoryTestBase<IPlayerRepository>
    {
        [Test]
        public void Can_Save_And_Retrieve()
        {
            Player p = new Player() { FirstName = "Cheese", LastName = "Burgler" };
            _Repository.Save(p);
            Assert.Greater(p.ID, 0);
        }

        [Test]
        public void Can_Find_By_Name()
        {
            string firstName = "O";
            Assert.Greater(_Repository.Find(firstName, null).Count, 0);
        }
    }
}
