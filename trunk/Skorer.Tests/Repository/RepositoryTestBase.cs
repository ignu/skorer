using System;
using NUnit.Framework;
using Skorer.DataAccess;
using Skorer.Core;
using Skorer.IOC;

namespace Skorer.Tests.Repository
{    
    public class RepositoryTestBase<T> where T : IFlushable, ITransactional
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
}
