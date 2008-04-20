﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Skorer.Core;
using Skorer.IOC;
using Skorer.DataAccess;

namespace Skorer.Tests
{
    [TestFixture]
    public class BuildDataBase
    {
        [SetUp]
        public void CreateSchema()
        {
            Configuration cfg = new NHibernate.Cfg.Configuration();
            SchemaExport exporter = new SchemaExport(cfg.Configure());
            exporter.Create(true, true);
            exporter.Execute(false, true, false, true);
        }

        [Test]
        public void AddData()
        {
            _AddGames();
            _AddPlayers();
        }

        private static void _AddPlayers()
        {
            Container.Resolve<IRepository<Player, int>>().Save(
                            new Player { FirstName = "Optimus", LastName="Prime" });
            Container.Resolve<IRepository<Player, int>>().Save(
                            new Player { FirstName = "Mega", LastName="Tron" });
 
        }

        private static void _AddGames()
        {
            var newGame = new Game { Name = "Soccer"};
            IRepository<Game, int> gameRepository = Container.Resolve<IRepository<Game, int>>();
            gameRepository.Save(newGame);
            newGame = new Game { Name = "Carcassonne"};
            gameRepository.Save(newGame);
        }
    }
}
