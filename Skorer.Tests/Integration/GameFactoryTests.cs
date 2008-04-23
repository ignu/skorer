using System;
using NUnit.Framework;
using Skorer.Services;

namespace Skorer.Tests.Integration
{
    [TestFixture]
    public class GameFactoryTests
    {
        IGameDataFactory _GameFactory;

        [SetUp]
        public void Setup()
        {
            _GameFactory = IOC.Container.Resolve<IGameDataFactory>();
        }

        [Test]
        public void Can_List_Games()
        {            
            Assert.That(_GameFactory.GetGames().Contains("Bowling"));
        }


        [Test]
        public void CanSaveGames()
        {
            _GameFactory.LoadGame("Bowling");
        }
    }
}
