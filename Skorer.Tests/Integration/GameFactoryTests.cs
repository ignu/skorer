using System;
using NUnit.Framework;
using Skorer.Services;

namespace Skorer.Tests.Integration
{
    [TestFixture]
    public class GameFactoryTests
    {
        IGameFactory _GameFactory;

        [Test]
        public void Can_List_Games()
        {
            _GameFactory = IOC.Container.Resolve<IGameFactory>();
            Assert.That(_GameFactory.GetGames().Contains("Bowling"));
        }
    }
}
