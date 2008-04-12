using System;
using NUnit.Framework;
using Skorer.DataAccess;
using Skorer.Core;
using Skorer.IOC;

namespace Skorer.Tests.Repository
{
    [TestFixture]
    public class MatchTests : RepositoryTestBase<IRepository<Match, int>>
    {
        [Test]
        public void CanSaveAndRetrieveMatch()
        {
            Match match = new Match();
            _Repository.Save(match);
            Assert.Greater(match.ID, 0);
        }
        
    }
}
