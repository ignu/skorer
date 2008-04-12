using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Skorer.DataAccess;
using Skorer.Core;
using Skorer.IOC;

namespace Skorer.Tests.Repository
{
    [TestFixture]
    public class RepositoryTestBase<T> where T : IRepository, ITransactional
    {

        internal T _Repository;

        [TestFixtureSetUp]
        public void InitDal()
        {
            _Repository = Container.Resolve<T>();
        }

        [SetUp]
        public void SetUp()
        {
            _Repository.StartTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            _Repository.Flush();
            _Repository.AbandonTransaction();
        }
    }
    [TestFixture]
    public class Games : RepositoryTestBase<IGameRepository>
    {
        [Test]
        public void CanSaveAndRetrieve()
        {
            Game game = new Game { Name = "Soccer" };
            _Repository.Save(game);
            Assert.Greater(game.ID, 0);            
        }

        [Test]
        public void Test()
        {
            Assert.IsNotNull(Container.Resolve<INHibernateSessionManager>());
                
        }
    }
}
