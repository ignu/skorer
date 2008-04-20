using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Skorer.Web.Controllers;
using Skorer.DataAccess;
using Moq;
using Skorer.Core;
using Castle.MonoRail.Framework.Test;
using Castle.MonoRail.Framework;

namespace Skorer.Tests.Controllers
{
    [TestFixture]
    public class MatchControllerTests
    {
        MatchController _Controller;
        Mock<IMatchRepository> _MatchRepositoryMock;
        Mock<IRepository<Game, int>> _GameRepositoryMock;
        Mock<IRepository<Player, int>> _PlayerRepositoryMock;


        [SetUp]
        public void SetUp()
        {
            _MatchRepositoryMock = new Mock<IMatchRepository>();
            _GameRepositoryMock = new Mock<IRepository<Game, int>>();
            _PlayerRepositoryMock = new Mock<IRepository<Player, int>>();
            _Controller = new MatchController(_MatchRepositoryMock.Object, _GameRepositoryMock.Object, _PlayerRepositoryMock.Object);
            _Controller.Contextualize(new MockEngineContext(), new ControllerContext());
        }

        [Test]
        public void Can_Create_Match()
        {
            Game game = new Game { Name = "Politics" };
            _GameRepositoryMock.Expect(g => g.GetById(1)).Returns(game);
            Match newMatch = new Match { ID = 0, Game = game };
            _GameRepositoryMock.Expect(g => g.GetAll()).Returns(new List<Game> { game });


            _MatchRepositoryMock.Expect(m => m.Save(It.Is<Match>(ma => ma.Game.Name == "Politics"))).Returns(newMatch);

            _Controller.Create(1);
            Assert.AreEqual((_Controller.Context.Session["Match"] as Match).ID, newMatch.ID);
        }

        [Test]
        public void Can_Add_Player()
        {
            Game game = new Game { Name = "Politics" };
            Match newMatch = new Match { ID = 0, Game = game };
            _Controller.Context.Session["Match"] = newMatch;

            Player player = new Player { FirstName = "Tony" } ;
            
            _PlayerRepositoryMock.Expect(p => p.GetById(2)).Returns(player);
            _PlayerRepositoryMock.Expect(p => p.Save(player)).Returns(player);
            
            _Controller.AddPlayers(2);
            Assert.Greater((_Controller.Context.Session["Match"] as Match).Players.Count, 0);                        
        }
    }
}
